using RMQHelperDll.MessagesDef;
using RMQHelperDLL;
using RMQHelperDLL.MessagesDef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTemplate.HandledMessages
{
    internal class MsgIsAlive : MessageBase, IMessageActions
    {
        MQConnection? _connection;

        public MsgIsAlive() : base("IsAliveMessage") { }

        public MsgIsAlive(RMQEnveloppe msgEnveloppe) : base("IsAliveMessage")
        {
            MessageName = msgEnveloppe.MessageName;
            _msgEnveloppe = msgEnveloppe;
        }

        public override MessageBase GetMessageInstance(RMQEnveloppe msgEnveloppe)
        {
            return new MsgIsAlive(msgEnveloppe);
        }

        public override string GetMessageText()
        {
            if (_msgEnveloppe == null)
                return "No message content";
            return $"{_msgEnveloppe.Sender}::{_msgEnveloppe.MessageText}";
        }


        public override async Task ProcessMessageActions()
        {
            // Traitement du message IsAlive : répondre à l'expéditeur pour confirmer que le service est actif
            if (_connection != null && _msgEnveloppe != null)
            {
                await _connection.SendMessage(_msgEnveloppe.Sender, "ImAlive", $"Yes I am alive {DateTime.Now}", null);

            }

        }

        public void SetupMessageQ(MQConnection connection)
        {
            _connection = connection;
        }
    }
}