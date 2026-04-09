using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MQTestBench.MQSystem.Messages
{
    internal class MessageFactory
    {
        List<IMessageActions> _messageInstances;

        public MessageFactory()
        {
            var interfaceType = typeof(IMessageActions);

            // 1. Obtenir tous les types dans l'assemblée actuelle
            var types = Assembly.GetExecutingAssembly().GetTypes();

            // 2. Filtrer avec LINQ
            var implementations = types.Where(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract).ToList();

            _messageInstances = new List<IMessageActions>();

            foreach (var impl in implementations)
            {
                try
                {
                    IMessageActions instance = (IMessageActions)Activator.CreateInstance(impl);
                    if (instance != null)
                        _messageInstances.Add(instance);
                }
                catch { }
            }
        }
    }
}
