using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsEtConfig.Logs.Implementations
{
    public class FileLogger : ILog, IDisposable
    {
        private string? _basePath;
        private string? _baseFileName;
        private string _baseExtension;
        private bool _isValid;
        private bool _isInitialized;

        private StreamWriter? _outputFile;

        public FileLogger(string fileName, bool useDateInFileName) 
        {
            _baseFileName = Path.GetFileName(fileName);
            _basePath = Path.GetDirectoryName(fileName);
            _baseExtension = Path.GetExtension(fileName);

            if(_baseExtension == string.Empty)
            {
                _baseExtension = ".log";
            }

            UseDateInFileName = useDateInFileName;

            _isValid = _basePath != null && _basePath != string.Empty && _baseFileName != null && _baseFileName != string.Empty;
        }

        public bool IsValid
        {
            get { return _isValid; }
        }

        public void Initialize()
        {
            if (!IsValid)
                throw new InvalidOperationException("FileLogger is not valid. Please check the file name and path.");

            string actualFileName = GetActualFileName();
            string fullPath = Path.Combine(_basePath, actualFileName);

            //is file already in use by another process ?
            _outputFile = new StreamWriter(fullPath, append: true);
            _isInitialized = true;

        }

        public bool UseDateInFileName { get; set; }

        public string GetActualFileName()
        {
            if (UseDateInFileName)
            {
                return $"{_baseFileName}_{DateTime.Now:yyyyMMdd}{_baseExtension}";
            }
            return _baseFileName;
        }

        public void LogBlock(string title, int level, List<string> messages)
        {
            if (!_isInitialized)
                throw new InvalidOperationException("FileLogger is not initialized. Please call Initialize() before logging.");

            const string separator = "**********************************************************************";

            _outputFile.WriteLine();
            _outputFile.WriteLine(separator);
            _outputFile.WriteLine($"* {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}");
            _outputFile.WriteLine($"* {title}");
            _outputFile.WriteLine(separator);

            foreach (var message in messages)
            {
                _outputFile.WriteLine($"* {message}");
            }

            _outputFile.WriteLine(separator);

            _outputFile.WriteLine();
            _outputFile.Flush();
        }

        public void LogCritical(string message)
        {
            Log(" !!! ", message);
        }

        public void LogDebug(string message)
        {
            Log("  D  ", message);
        }

        public void LogError(string message)
        {
            Log("  !  ", message);
        }

        public void LogInfo(string message)
        {
            Log("  ?  ", message);
        }

        public void LogTrace(string message)
        {
            Log("  T  ", message);
        }

        public void LogWarning(string message)
        {
            Log(" !W! ", message);
        }

        private void Log(string token, string message, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            if (!_isInitialized)
                throw new InvalidOperationException("FileLogger is not initialized. Please call Initialize() before logging.");

            _outputFile.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{token}] {message}");
            _outputFile.Flush();
        }

        public void Dispose()
        {
            _outputFile?.Close();
            _outputFile?.Dispose();
            _isInitialized = false;
        }
    }
}
