using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace StudentManagement.DAL.Logging
{
    // Điểm vào duy nhất để lấy logger trong toàn bộ dự án.
    public static class AppLogger
    {
        private static readonly string logDirectory =
            Path.Combine(AppContext.BaseDirectory, "Logs");

        private static readonly ILoggerFactory factory =
            LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Information);           
                builder.AddProvider(new FileLoggerProvider(logDirectory));
            });

        public static ILogger GetLogger<T>() => factory.CreateLogger<T>();

        public static ILogger GetLogger(string category) =>
            factory.CreateLogger(category);
    }

    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string logDirectory;
        private static readonly object fileLock = new object();

        public FileLoggerProvider(string logDirectory)
        {
            this.logDirectory = logDirectory;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName, logDirectory, fileLock);
        }

        public void Dispose() { }
    }

    public class FileLogger : ILogger
    {
        private readonly string category;
        private readonly string logDirectory;
        private readonly object fileLock;

        public FileLogger(string category, string logDirectory, object fileLock)
        {
            this.category = category;
            this.logDirectory = logDirectory;
            this.fileLock = fileLock;
        }

        public IDisposable? BeginScope<TState>(TState state)
            where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            try
            {
                string message = formatter(state, exception);

                string line =
                    $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} " +
                    $"[{logLevel}] {category} - {message}";

                if (exception != null)
                    line += Environment.NewLine + exception;

                lock (fileLock)
                {
                    Directory.CreateDirectory(logDirectory);

                    string file = Path.Combine(
                        logDirectory, $"log_{DateTime.Now:yyyyMMdd}.txt");

                    File.AppendAllText(file, line + Environment.NewLine);
                }
            }
            catch
            {
                // Lỗi ghi log không được làm sập ứng dụng.
            }
        }
    }
}
