using System;
using System.IO;

namespace WeatherApp.Services
{
    public static class Logger
    {
        private static readonly string logFilePath = "logs/weatherapp.log";

        static Logger()
        {
            // Ensure the logs directory exists
            var logDirectory = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(logFilePath) ?? string.Empty);
            }
        }

        public static void LogInfo(string message)
        {
            WriteLog("INFO", message);
        }

        public static void LogError(string message, Exception? ex = null)

        {
            var errorMessage = $"{message} {ex?.Message} {ex?.StackTrace}";
            WriteLog("ERROR", errorMessage);
        }

        private static void WriteLog(string logLevel, string message)
        {
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {message}";
            using (var writer = new StreamWriter(logFilePath, true)) // Append to file
            {
                writer.WriteLine(logEntry);
            }
        }

        public static string GetLogFilePath()
        {
            return Path.GetFullPath(logFilePath);
        }
    }
}
