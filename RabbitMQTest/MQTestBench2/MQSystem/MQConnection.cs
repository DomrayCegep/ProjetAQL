using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMQHelperDLL;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


namespace MQTestBench.MQSystem
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

        public string QueueName { get; private set; }
        public string ServerAddress { get; private set; }

        public async Task Connect()
        { 
            _mq = new RMQConnectionHelper(@"amqp://" + ServerAddress, QueueName);
            await _mq.Connect();

            _consumer = new AsyncEventingBasicConsumer(_mq.CurrentChannel);
            _consumer.ReceivedAsync += OnMessageReceived;
        }

        private async Task OnMessageReceived(object sender, BasicDeliverEventArgs ea)
        { 
            var body = ea.Body.ToArray();
            RMQEnveloppe message = RMQEnveloppe.Deserialise(body);
            

        }
    }
}
