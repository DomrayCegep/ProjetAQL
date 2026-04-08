using RabbitMQ.Client;
using System.Data;

namespace RMQHelperDLL
{
    /// <summary>
    /// Provides static helper methods for establishing connections to RabbitMQ and sending messages to queues
    /// asynchronously.
    /// </summary>
    /// <remarks>This class simplifies common RabbitMQ operations by offering a straightforward API for
    /// connecting to a RabbitMQ server and publishing messages. All methods are asynchronous and intended for use in
    /// applications that require non-blocking messaging operations. The class is not intended to be
    /// instantiated.</remarks>
    public class RMQConnectionHelper
    {
        public RMQConnectionHelper(string uri, string queueName) 
        {
            CurrentUri = uri;
            CurrentQueueName = queueName;
        }

        public string CurrentUri { get; private set; }
        public string CurrentQueueName { get; private set; }

        public IChannel CurrentChannel { get; private set; }


        /// <summary>
        /// Establishes an asynchronous connection to the RabbitMQ server using the current URI and queue name.
        /// </summary>
        /// <remarks>Ensure that the CurrentUri and CurrentQueueName properties are set before calling
        /// this method. This method should be awaited to ensure the connection is fully established before performing
        /// further operations.</remarks>
        /// <returns>A task that represents the asynchronous connect operation.</returns>
        public async Task Connect()
        {
            CurrentChannel = await ConnectOnRabbitMQ(CurrentUri, CurrentQueueName);
        }

        /// <summary>
        /// Asynchronously establishes a connection to a RabbitMQ server and creates a channel for communication with
        /// the specified queue.
        /// </summary>
        /// <remarks>The declared queue is non-durable, non-exclusive, and will not be automatically
        /// deleted. The caller is responsible for managing the channel's lifecycle.</remarks>
        /// <param name="uri">The URI of the RabbitMQ server to connect to. Must be a valid URI string.</param>
        /// <param name="queueName">The name of the queue to declare on the RabbitMQ server. If the queue does not exist, it will be created.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an instance of IChannel for
        /// communicating with the specified queue.</returns>
        private static async Task<IChannel> ConnectOnRabbitMQ(string uri, string queueName)
        {
            ConnectionFactory facto = new ConnectionFactory();
            facto.Uri = new Uri(uri);

            IConnection conn = await facto.CreateConnectionAsync();
            var channel = await conn.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            return channel;
        }

        /// <summary>
        /// Asynchronously sends a message to the specified queue using the provided channel.
        /// </summary>
        /// <remarks>Ensure that the channel is properly initialized and connected before calling this
        /// method. The method sets standard message properties, including reply-to and message identifiers, before
        /// publishing.</remarks>
        /// <param name="channel">The channel through which the message is sent. This must be an active and connected channel instance.</param>
        /// <param name="queueName">The name of the destination queue to which the message will be published. The queue must exist and be accessible by the channel.</param>
        /// <param name="messageTitle">Message name use to help deserialisation and interpretation</param>
        /// <param name="message">The message payload to send. This value must not be null or empty.</param>
        /// <returns>A task that represents the asynchronous send operation. The task completes when the message has been
        /// published to the queue.</returns>
        public async Task SendAsync(string queueName, string messageTitle,  string message)
        {

            var msg = new RMQEnveloppe(messageName: messageTitle, sender: CurrentChannel.CurrentQueue, messageText: message, string.Empty);


            BasicProperties properties = new BasicProperties();

            properties.ReplyTo = CurrentChannel.CurrentQueue;
            properties.MessageId = messageTitle;
            properties.AppId = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            properties.Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            await CurrentChannel.BasicPublishAsync(exchange: string.Empty, routingKey: queueName, mandatory: false, basicProperties: properties, body: msg.Serialise(), new CancellationToken());

        }

        /// <summary>
        /// Asynchronously sends a message with associated data to the specified queue using the provided channel.
        /// </summary>
        /// <remarks>Before calling this method, ensure that the channel is properly initialized and
        /// connected to the message broker. The method constructs a message envelope, attaches the provided data, and
        /// sets standard message properties before publishing to the specified queue.</remarks>
        /// <param name="channel">The channel used to send the message. This must be an active and connected channel instance.</param>
        /// <param name="queueName">The name of the destination queue. Must refer to an existing queue on the message broker.</param>
        /// <param name="messageTitle">Message name use to help deserialisation and interpretation</param>
        /// <param name="message">The text content of the message to send. Cannot be null or empty.</param>
        /// <param name="ds">A DataSet containing additional data to include with the message. Can be null if no extra data is required.</param>
        /// <returns>A task that represents the asynchronous send operation.</returns>
        public async Task SendAsyncWithData(string queueName, string messageTitle, string message, DataSet ds)
        {

            var msg = new RMQEnveloppe(messageName: messageTitle, sender: CurrentChannel.CurrentQueue, messageText: message, string.Empty);

            msg.SetData(ds);


            BasicProperties properties = new BasicProperties();

            properties.ReplyTo = CurrentChannel.CurrentQueue;
            properties.MessageId = messageTitle;
            properties.AppId = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name; ;
            properties.Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            await CurrentChannel.BasicPublishAsync(exchange: string.Empty, routingKey: queueName, mandatory: false, basicProperties: properties, body: msg.Serialise(), new CancellationToken());

        }
    }
}
