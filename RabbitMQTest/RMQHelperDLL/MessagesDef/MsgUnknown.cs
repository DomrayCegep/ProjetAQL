using RMQHelperDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMQHelperDll.MessagesDef
{
    internal class MsgUnknown : MessageBase
    {

        public MsgUnknown() : base("UnknownMessage") { }
        public MsgUnknown(RMQEnveloppe msgEnveloppe) : base("UnknownMessage")
        {
            MessageName = msgEnveloppe.MessageName;
            _msgEnveloppe = msgEnveloppe;
        }

        public override MessageBase GetMessageInstance(RMQEnveloppe msgEnveloppe)
        {
            return new MsgUnknown(msgEnveloppe);
        }

        public string GetMessageText()
        {
            if (_msgEnveloppe == null)
                return "Message non initialisé";
            return $"UnknownMessage.{_msgEnveloppe.MessageName}::{_msgEnveloppe.Sender}::{_msgEnveloppe.MessageText}";
        }

        public override async Task ProcessMessageActions()
        {
            Console.WriteLine($"Message inconnu reçu : {GetMessageText()}");
        }
    }
}
