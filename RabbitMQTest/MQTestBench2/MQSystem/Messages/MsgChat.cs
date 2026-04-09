using MQTestBench.MQSystem.Messages;
using RMQHelperDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTestBench2.MQSystem.Messages
{
    internal class MsgChat : IMessageActions
    {
        RMQEnveloppe? _msgEnveloppe;
        public MsgChat() { MessageName = "ChatMessage"; }

        public MsgChat(RMQEnveloppe msgEnveloppe) 
        { 
            MessageName = msgEnveloppe.MessageName;
            _msgEnveloppe = msgEnveloppe;
        }

        public string MessageName { get; set; }

        public void DoActions()
        {
            throw new NotImplementedException();
        }

        public IMessageActions GetMessageInstance(RMQEnveloppe msgEnveloppe)
        {
            return new MsgChat(msgEnveloppe);
        }

        public string GetMessageText()
        {
            if(_msgEnveloppe == null)
                return "No message content";
            return $"{_msgEnveloppe.Sender}::{_msgEnveloppe.MessageText}";   
        }
    }
}
