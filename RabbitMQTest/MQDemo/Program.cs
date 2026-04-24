using RMQHelperDLL;
using System.Drawing;

namespace MQDemo
{
    internal class Program
    {
        static Dictionary<string, string> _redirectBehavior = new Dictionary<string, string>();
        static string _mqAddress = string.Empty;
        static string _mqQueue = string.Empty;

        static ConsoleColor[] _availableColors;
        static Dictionary<string, ConsoleColor> _senderColors = new Dictionary<string, ConsoleColor>();
        static int actualAvailableColor = 0;

        static MQConnection _mqConnection;

        static ManualResetEventSlim _eventSignaler = new ManualResetEventSlim(false);

        static async Task Main(string[] args)
        {

            _availableColors = new ConsoleColor[8];
            _availableColors[0] = ConsoleColor.White;
            _availableColors[1] = ConsoleColor.Red;
            _availableColors[2] = ConsoleColor.Yellow;
            _availableColors[3] = ConsoleColor.Magenta;
            _availableColors[4] = ConsoleColor.Cyan;
            _availableColors[5] = ConsoleColor.Gray;
            _availableColors[6] = ConsoleColor.Green;
            _availableColors[7] = ConsoleColor.DarkYellow;


            foreach (var item in args)
            {
                var parts = item.Split(':');

                if (parts.Length == 2)
                {
                    _redirectBehavior.Add(parts[0], parts[1]);
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



            // Handle the received message  
            string redirectTo = _redirectBehavior.FirstOrDefault(x => x.Key == e.MessageName).Value;
            if (redirectTo != null)
            {
                var parts = redirectTo.Split('.');
                if (parts.Length == 2)
                {
                    Console.WriteLine($"Message reçu : {e.MessageName}");
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
                LogMessage(e.Sender, e.MessageName, e.MessageText);
            }
        }

        private static void LogMessage(string sender, string messageName, string messageText)
        {
            if (_senderColors.TryGetValue(sender, out ConsoleColor color))
            {
                Console.ForegroundColor = color;
            }
            else
            {
                //Search next available color in dictionary
                color = ConsoleColor.White;
                if(actualAvailableColor < _availableColors.Length)
                {
                    color = _availableColors[actualAvailableColor];
                    _senderColors.Add(sender, color);
                    actualAvailableColor++;
                }
                Console.ForegroundColor = color;

            }
            Console.WriteLine($">[{sender}][{messageName}]::{messageText}");
            Console.ResetColor();
        }
    }
}
