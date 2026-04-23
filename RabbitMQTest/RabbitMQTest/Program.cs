namespace RabbitMQTest
{
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;
    using RMQHelperDLL;
    using System.Data;

    internal static class Program
    {
        static async Task Main(string[] args)
        {

            // Configuration par défaut
            string currentQueueName = "hello"; // Nom de la file d'attente pour recevoir les messages
            string distantQueueName = "hello2"; // Nom de la file à qui on envoie les messages
            string adressServer = "192.168.92.129:5672"; // Adresse du serveur RabbitMQ (port par défaut 5672)

            string? line;

            adressServer = assignOrDefault("Quelle est l'adresse du serveur RabbitMQ?", adressServer);
            currentQueueName = assignOrDefault("Entrez un nom pour vous identifier", currentQueueName);
            distantQueueName = assignOrDefault("À qui vous voulez écrire?", distantQueueName);


            MQConnection mq;

            // Connexion à RabbitMQ et configuration du consommateur
            mq = new MQConnection(@"amqp://" + adressServer, currentQueueName);
            mq.MessageReceived += LogReceivedMessage;

            await mq.Connect();

            Console.WriteLine($"Connextion effectuée avec succès sur la file [{currentQueueName}]. Vous pouvez écrire un message ou exit pour quitter");

            line = "";
            while (true)
            {
                try
                {
                    line = Console.ReadLine();
                    if (line != "exit")
                        // Envoi du message à la file d'attente distante
                        await mq.SendMessage(distantQueueName, "ChatMessage", line, null);
                    else
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static string assignOrDefault(string question , string defaultValue)
        {
            string? input;
            Console.WriteLine(question + " " + $"( default = {defaultValue} )");
            input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? defaultValue : input.Trim();
        }



        private static void LogReceivedMessage(object? sender, RMQEnveloppe e)
        {
            RMQEnveloppe message = e;
       
            switch(message.MessageName)
            {
                case "ChatMessage":
                    Console.WriteLine($"Message de chat reçu de {sender} : {message.MessageText}");
                    break;

                case "DataMessage":
                    Console.WriteLine($"Message de données reçu de {sender} : {message.MessageText}");
                    break;

                default:
                    Console.WriteLine($"Message générique reçu de {sender} : {message.MessageText}");
                    break;
            }

            if (message.XmlData != null && message.XmlData != string.Empty)
            {
                DataSet ds = message.GetData();
                    
                Console.WriteLine($"DataSet reçu : {ds.DataSetName}");
                Console.WriteLine($"Contenu du DataSet :");
                Console.WriteLine($"Nombre de tables {ds.Tables.Count}");

                   foreach (DataTable table in ds.Tables)
                    {
                        Console.WriteLine($"Table: {table.TableName}");
                        foreach (DataRow row in table.Rows)
                        {
                            foreach (DataColumn column in table.Columns)
                            {
                                Console.Write($"{column.ColumnName}: {row[column]} ");
                            }
                            Console.WriteLine();
                        }
                    }
            }

            Console.WriteLine($"{message.Sender}.{message.MessageName}:{message.MessageText}");
        }




        private static DataSet GetDataFakeDataSet()
        {
            DataSet dsTest = new DataSet("DataSetName1");
            DataTable dt = dsTest.Tables.Add("Table1");
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Columns.Add("Column3");

            dt.Rows.Add("Value1", "Value2", "Value3");

            return dsTest;

        }
    }
}
