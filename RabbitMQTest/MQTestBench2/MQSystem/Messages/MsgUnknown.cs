using MQTestBench.MQSystem.Messages;
using RMQHelperDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTestBench2.MQSystem.Messages
{
    internal class MsgUnknown : IMessageActions
    {
        RMQEnveloppe? _msgEnveloppe;

        public MsgUnknown() { MessageName = "UnknownMessage"; }

        public MsgUnknown(RMQEnveloppe msgEnveloppe)
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
            return new MsgUnknown(msgEnveloppe);
        }

        public string GetMessageText()
        {
            if (_msgEnveloppe == null)
                return "Message non initialisé";
            return $"UnknownMessage.{_msgEnveloppe.MessageName}::{_msgEnveloppe.Sender}::{_msgEnveloppe.MessageText}";
        }
    }
}
