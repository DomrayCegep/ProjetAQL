using RMQHelperDLL;

namespace MQDemo
{
    internal class Program
    {
        static Dictionary<string, string> _redirectBehavior = new Dictionary<string, string>();
        static string _mqAddress = string.Empty;
        static string _mqQueue = string.Empty;

        static MQConnection _mqConnection;

        static ManualResetEventSlim _eventSignaler = new ManualResetEventSlim(false);

        static async Task Main(string[] args)
        {

            foreach (var item in args)
            {
                var parts = item.Split(':');
                
                if (parts.Length == 2)
                {
                    _redirectBehavior.Add(parts[0],parts[1]);
                }
                if (parts.Length == 3)
                {
                    _mqAddress = parts[1] + ":" + parts[2];
                    _mqQueue = parts[0];
                }

            }

            if (_mqAddress == string.Empty || _mqQueue == string.Empty)
            {
                Console.WriteLine("Usage: MQDemo.exe <messageNameFrom:redirectTo.messageName> <CurrentQueue:mqAddress:mqPort>");
                Console.WriteLine("Example: MQDemo.exe TestMessage:ServiceB.NextMessage MyQueue:localhost:5672");
                return;
            }

            // Connection MQ
            _mqConnection = new MQConnection(_mqQueue, _mqAddress);
            
            _mqConnection.MessageReceived += OnMessageReceived;
            await _mqConnection.Connect();


            Console.WriteLine($"Connexion réussie! [{_mqConnection.QueueName}]");
            Console.WriteLine($"tapez une touche pour quitter");

            var line = Console.ReadLine();

            //_eventSignaler.Wait();
        }

        private static async void OnMessageReceived(object? sender, RMQEnveloppe e)
        {

            Console.WriteLine($"Message reçu : {e.MessageName}");

            // Handle the received message  
            string redirectTo = _redirectBehavior.FirstOrDefault(x => x.Key == e.MessageName).Value;
            if (redirectTo != null)
            {
                var parts = redirectTo.Split('.');
                if (parts.Length == 2)
                {
                    Console.WriteLine($"Redirection vers : {parts[1]}");
                    await _mqConnection.SendMessage(parts[0], parts[1], e.MessageText + $":{_mqQueue}", null);

                }
            }
            else if (e.MessageName == "Exit")
            {
                _eventSignaler.Set();
            }
            else
            {
                Console.WriteLine($"Received message: {e.MessageName} with text: {e.MessageText}");

            }
        }
    }
}
