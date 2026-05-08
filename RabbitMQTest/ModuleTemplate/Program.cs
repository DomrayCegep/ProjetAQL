using MySql.Data.MySqlClient;
using RMQHelperDll.MessagesDef;
using RMQHelperDLL;
using RMQHelperDLL.MessagesDef;
using ServiceTemplate.HandledMessages;
using System.Diagnostics;

namespace ModuleTemplate
{
    /// <summary>
    /// Template d'application qui écoute une Queue, traite les messages (fais des insertions dans une DB) et/ou envoie des réponses
    /// </summary>
    internal static class Program
    {
        static MessageFactory _messageFactory;
        static MQConnection? _mqc = null;
        static MySqlConnection? _db = null;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            try
            {
                _messageFactory = new MessageFactory();

                string connectionString = "Server=192.168.92.131;User ID=client2;Password=mon_pwd;Database=ClientDB";
                string connectedQueue = "TestQueue";
                string mqServerAddress = "192.168.92.129:5672";

                //Connection au MQ
                _mqc = new MQConnection(connectedQueue, mqServerAddress);
                await _mqc.Connect();
                _mqc.MessageReceived += MessageReceived;

                Console.WriteLine($"Connecté sur {_mqc.QueueName}");


                //Connection à la DB
                _db = new MySqlConnection(connectionString);
                _db.Open();

                Console.WriteLine("Connexion à la DB réussie !");

                Console.WriteLine($"Faire Enter pour terminer...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void MessageReceived(object? sender, RMQEnveloppe e)
        {
            //MessageBox.Show($"Message reçu: {e.MessageName} \n {e.GetMessageText()}", "Message Reçu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Console.WriteLine($"Message reçu! [{e.Sender}] [{e.MessageName}]");
            MessageBase mb = _messageFactory.GetMessageInstance(e);
            Console.WriteLine($"Type: {mb.GetType().Name}");

            if (mb is IMessageActions)
            {
               ((IMessageActions)mb).SetupMessageQ(_mqc);
            }

            if (mb is IDBActions)
            {
                ((IDBActions)mb).SetupDB(_db);
            }

            mb.ProcessMessageActions().Wait();

        }
    }
}
