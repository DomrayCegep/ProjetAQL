using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTestBench.MQSystem.Messages
{
    internal class MessageFactory
    {
        List<IMessage> _messageInstances;

        public MessageFactory()
        {
            var interfaceType = typeof(IMessage);

            // 1. Obtenir tous les types dans l'assemblée actuelle
            var types = Assembly.GetExecutingAssembly().GetTypes();

            // 2. Filtrer avec LINQ
            var implementations = types.Where(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract).ToList();

            _messageInstances = new List<IMessage>();

            foreach (var impl in implementations)
            {
                try
                {
                    var instance = (IMessage)Activator.CreateInstance(impl);
                    _messageInstances.Add(instance);
                }
            }
        }
    }
}
