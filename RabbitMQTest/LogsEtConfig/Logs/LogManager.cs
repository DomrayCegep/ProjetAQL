using LogsEtConfig.Logs.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsEtConfig.Logs
{
    public class LogManager : ILog
    {
        List<ILog> _loggers;

        public LogManager() 
        {
            _loggers = new List<ILog>();
            _loggers.Add(new ConsoleLogger()); // default logger
        }

        public void AddLogger(ILog logger)
        {
            _loggers.Add(logger);
        }

        public void LogBlock(string title, int level, List<string> messages)
        {
            foreach (var logger in _loggers)
            {
                logger.LogBlock(title, level, messages);
            }
        }

        #region Redirection vers les loggers inscrits

        public void LogCritical(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogCritical(message);
            }   
        }

        public void LogDebug(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogDebug(message);
            }   
        }

        public void LogError(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogError(message);
            }   
        }

        public void LogInfo(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogInfo(message);
            }       
        }

        public void LogTrace(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogTrace(message);
            }   
        }

        public void LogWarning(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogWarning(message);
            }   
        }
        #endregion
    }
}
