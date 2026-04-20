using LogsEtConfig.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsEtConfig.Logs.Implementations
{
    public class ConsoleLogger : ILog
    {
        public void LogBlock(string title, int level, List<string> messages)
        {
            
            switch (level)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }

            const string separator = "*****************************************";

            Console.WriteLine(); 
            Console.WriteLine(separator);
            Console.WriteLine($"* {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}");
            Console.WriteLine($"* {title}");
            Console.WriteLine(separator);

            foreach (var message in messages)
                {
                    Console.WriteLine($"* {message}");
                }

            Console.WriteLine(separator);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void LogCritical(string message)
        {
            Log(" !!! ", message, ConsoleColor.White, ConsoleColor.DarkRed);
        }

        public void LogDebug(string message)
        {
            Log("  D  ", message, ConsoleColor.Cyan, ConsoleColor.Black);
        }

        public void LogError(string message)
        {
            Log("  !  ", message, ConsoleColor.White, ConsoleColor.Red);
        }

        public void LogInfo(string message)
        {
            Log("  ?  ", message, ConsoleColor.Green, ConsoleColor.Black);
        }

        public void LogTrace(string message)
        {
            Log("  T  ", message, ConsoleColor.White, ConsoleColor.Black);
        }

        public void LogWarning(string message)
        {
            Log(" !W! ", message, ConsoleColor.Black, ConsoleColor.Yellow);
        }

        private void Log(string token, string message, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} [{token}] {message}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
