using Microsoft.Extensions.Logging;
using MoneyTransferAPI.Interface;

namespace MoneyTransferAPI.Infrastructure.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;
        private readonly object _lock = new object();

        public FileLogger(string path)
        {
            _filePath = path;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // You can filter specific log levels here if needed
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = formatter(state, exception);

            if (logLevel == LogLevel.Error)
            {
                message = "[ERROR] " + message;
            }

            WriteTextToFile(message);
        }

        private void WriteTextToFile(string message)
        {
            lock (_lock)
            {
                File.AppendAllText(_filePath, message + Environment.NewLine);
            }
        }
    }
}
