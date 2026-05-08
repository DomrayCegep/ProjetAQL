using MySql.Data.MySqlClient;
using RMQHelperDll.MessagesDef;
using RMQHelperDLL;
using RMQHelperDLL.MessagesDef;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTemplate.HandledMessages
{
    internal class MsgIsValidUser : MessageBase, IMessageActions, IDBActions
    {
        MQConnection? _connection;
        MySqlConnection? _db;

        public MsgIsValidUser() : base("IsValidUser") { }

        public MsgIsValidUser(RMQEnveloppe msgEnveloppe) : base("IsValidUser")
        {
            MessageName = msgEnveloppe.MessageName;
            _msgEnveloppe = msgEnveloppe;
        }

        public override MessageBase GetMessageInstance(RMQEnveloppe msgEnveloppe)
        {
            return new MsgIsValidUser(msgEnveloppe);
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
            if (_connection != null && _msgEnveloppe != null && _db != null)
            {
                DataSet ds = new DataSet();

                string request = "SELECT * FROM UserTable WHERE UserName = @username AND IsActive = 1";
                MySqlCommand cmd = new MySqlCommand(request, _db);
                cmd.Parameters.AddWithValue("@username", _msgEnveloppe.MessageText);

                // Le DataAdapter fait le pont entre la DB et le DataSet
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    // Remplit le DataSet (ouvre et ferme la connexion automatiquement)
                    adapter.Fill(ds, "TableMessages");
                }

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    await _connection.SendMessage(_msgEnveloppe.Sender, "AnswerIsValidUser", $"Yes user is valid", null);
                }
                else
                {
                    await _connection.SendMessage(_msgEnveloppe.Sender, "AnswerIsValidUser", $"No user is not valid", null);
                }

                
            }

        }

        public void SetupDB(MySqlConnection db)
        {
            _db = db;
        }

        public void SetupMessageQ(MQConnection connection)
        {
            _connection = connection;
        }
    }
}