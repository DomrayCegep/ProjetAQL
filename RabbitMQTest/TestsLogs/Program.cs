using LogsEtConfig.Logs;
using LogsEtConfig.Logs.Implementations;

namespace TestsLogs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello, World!");

                LogManager lm = new LogManager();

                FileLogger fl = new FileLogger(@"c:\temp\logs\log.txt", true);
                fl.Initialize();

                lm.AddLogger(fl);

                lm.LogInfo("Test info");
                lm.LogError("Test error");
                lm.LogCritical("Test critical");
                lm.LogDebug("Test debug");
                lm.LogTrace("Test trace");
                lm.LogWarning("Test warning");

                List<string> messages = new List<string>()
            {
                "Message 1",
                "Message 2",
                "Message 3"
            };

                lm.LogBlock("Test block niveau 1", 1, messages);
                lm.LogBlock("Test block niveau 2", 2, messages);
                // lm.LogBlock("Test block niveau 3", 3, messages);

                LogContext loggerWithContext = lm.GetLoggerWithContext("Main");

                loggerWithContext.LogInfo("Test info with context");
                loggerWithContext.LogError("Test LogError with context");
                loggerWithContext.LogCritical("Test Critical with context");


                loggerWithContext.SetDetailContext("Detail");

                loggerWithContext.LogDebug("Test debug with context");
                loggerWithContext.LogTrace("Test trace with context");
                loggerWithContext.LogWarning("Test warning with context");


                loggerWithContext.LogBlock("Test block niveau 1", 1, messages);
                loggerWithContext.LogBlock("Test block niveau 2", 2, messages);
                // loggerWithContext.LogBlock("Test block niveau 3", 3, messages);



                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
