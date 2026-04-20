using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsEtConfig.Logs
{
    public class LogContext : ILog
    {
        private ILog _logger;

        public LogContext(string mainContext, ILog logger) 
        {
            MainContext = mainContext;
            DetailContext = string.Empty;
            _logger = logger;
        }

        public string MainContext { get; internal set; }
        public string DetailContext { get; internal set; }

        public string GetFullContext()
        {
            if (DetailContext == string.Empty)
                return $"{MainContext}.{DetailContext}";
            else 
                return MainContext;
        }

        public void SetDetailContext(string detailContext)
        {
            DetailContext = detailContext;
        }

        #region Redirection vers le logger principal
        public void LogInfo(string message)
        {
            _logger.LogInfo($"[{GetFullContext()}] >> {message}");
        }

        public void LogError(string message)
        {
            _logger.LogError($"[{GetFullContext()}] >> {message}");
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning($"[{GetFullContext()}] >> {message}");
        }

        public void LogDebug(string message)
        {
            _logger.LogDebug($"[{GetFullContext()}] >> {message}");
        }

        public void LogCritical(string message)
        {
            _logger.LogCritical($"[{GetFullContext()}] >> {message}");
        }

        public void LogTrace(string message)
        {
            _logger.LogTrace($"[{GetFullContext()}] >> {message}");
        }

        public void LogBlock(string title, int level, List<string> messages)
        {
            _logger.LogBlock($"[{GetFullContext()}] >> {title}", level, messages);
        }
        #endregion

    }
}
