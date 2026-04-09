using MQTestBench2.MQSystem.Messages;
using RMQHelperDLL;
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
        IMessageActions _defaultMessage;

        public MessageFactory()
        {
            var interfaceType = typeof(IMessageActions);

            // 1. Obtenir tous les types dans l'assemblée actuelle
            var types = Assembly.GetExecutingAssembly().GetTypes();

            // 2. Filtrer avec LINQ
            var implementations = types.Where(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract).ToList();

            _messageInstances = new List<IMessageActions>();
            _defaultMessage = new MsgUnknown(); // Par exemple, une instance par défaut

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

        public IMessageActions GetMessageInstance(RMQEnveloppe msgEnveloppe)
        {
            var msg = _messageInstances.FirstOrDefault(m => m.MessageName == msgEnveloppe.MessageName);
            if (msg == null)
            {
                return _defaultMessage.GetMessageInstance(msgEnveloppe);
            }
            else
            {
                return msg.GetMessageInstance(msgEnveloppe);
            }

        }
    }
}
