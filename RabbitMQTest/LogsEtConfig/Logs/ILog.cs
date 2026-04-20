namespace LogsEtConfig.Logs
{
    public interface ILog
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogWarning(string message);
        void LogDebug(string message);
        void LogCritical(string message);
        void LogTrace(string message);

        void LogBlock(string title, int level, List<string> messages);

    }
}
