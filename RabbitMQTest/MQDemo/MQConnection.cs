using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMQHelperDLL;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Data;

namespace MQDemo
{
    internal class MQConnection
    {
        RMQConnectionHelper? _mq;
        AsyncEventingBasicConsumer? _consumer;

        public MQConnection(string queueName, string addressServer)
        {
            QueueName = queueName;
            ServerAddress = addressServer;
        }

        public event EventHandler<RMQEnveloppe> MessageReceived;

        public string QueueName { get; private set; }
        public string ServerAddress { get; private set; }

        public async Task Connect()
        { 
            _mq = new RMQConnectionHelper(@"amqp://" + ServerAddress, QueueName);
            await _mq.Connect();

            _consumer = new AsyncEventingBasicConsumer(_mq.CurrentChannel);
            _consumer.ReceivedAsync += OnMessageReceived;

            // Démarrage de la consommation des messages
            await _mq.CurrentChannel.BasicConsumeAsync(QueueName, autoAck: true, consumer: _consumer);
        }

        public async Task SendMessage(string destination, string messageName, string? messageText, DataSet? messageData)
        { 
            if (_mq == null)
                throw new InvalidOperationException("Se connecter avant de pouvoir envoyer des messages");

            await _mq.SendAsyncWithData(destination, messageName, messageText ?? string.Empty, messageData ?? new DataSet());
        }

        private async Task OnMessageReceived(object sender, BasicDeliverEventArgs ea)
        { 
            var body = ea.Body.ToArray();
            RMQEnveloppe message = RMQEnveloppe.Deserialise(body);
            MsgReceived(message);
        }

        private void MsgReceived(RMQEnveloppe msg)
        { 
            MessageReceived?.Invoke(this, msg);
        }
    }
}
