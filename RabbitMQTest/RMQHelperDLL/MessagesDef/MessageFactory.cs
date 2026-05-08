using RMQHelperDLL;
using System.Reflection;

namespace RMQHelperDll.MessagesDef
{
    public sealed class MessageFactory
    {
        List<MessageBase> _messageInstances;
        MessageBase _defaultMessage;

        public MessageFactory()
        {
            var interfaceType = typeof(MessageBase);

            // 1. Obtenir tous les types dans l'assemblée actuelle
            var types = Assembly.GetCallingAssembly().GetTypes();

            // 2. Filtrer avec LINQ
            var implementations = types.Where(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract).ToList();

            _messageInstances = new List<MessageBase>();
            _defaultMessage = new MsgUnknown(); // Par exemple, une instance par défaut

            foreach (var impl in implementations)
            {
                try
                {
                    MessageBase instance = (MessageBase)Activator.CreateInstance(impl);
                    if (instance != null)
                        _messageInstances.Add(instance);
                }
                catch { }
            }
        }

        public MessageBase GetMessageInstance(RMQEnveloppe msgEnveloppe)
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
