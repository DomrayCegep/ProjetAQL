using RMQHelperDLL;
using RMQHelperDll.MessagesDef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTestBench2.MQSystem.Messages
{
    internal class MsgChat : MessageBase
    {
        
        public MsgChat() : base( "ChatMessage"){ }
            
        public MsgChat(RMQEnveloppe msgEnveloppe) : base("ChatMessage")
        { 
            MessageName = msgEnveloppe.MessageName;
            _msgEnveloppe = msgEnveloppe;
        }

        public string MessageName { get; set; }

        public void DoActions()
        {
            throw new NotImplementedException();
        }

        public override MessageBase GetMessageInstance(RMQEnveloppe msgEnveloppe)
        {
            return new MsgChat(msgEnveloppe);
        }

        public string GetMessageText()
        {
            if(_msgEnveloppe == null)
                return "No message content";
            return $"{_msgEnveloppe.Sender}::{_msgEnveloppe.MessageText}";   
        }

        public override Task ProcessMessageActions()
        {
            throw new NotImplementedException();
        }
    }
}
