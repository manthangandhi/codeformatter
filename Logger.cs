using System;
using System.IO;

namespace CodeFormatterApp
{
    public static class Logger
    {

        private static readonly string LogFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        private static readonly int DaysToKeep = 3;

        // private static readonly string logFilePath = "error_log.txt";


        // Call this method when the app starts (e.g., in Form1 constructor or Load event)
        public static void InitializeLogger()
        {
            try
            {
                // Ensure Logs folder exists
                if (!Directory.Exists(LogFolderPath))
                {
                    Directory.CreateDirectory(LogFolderPath);
                    return; // No files to clean up if folder is new
                }

                // Get all log files
                string[] logFiles = Directory.GetFiles(LogFolderPath, "ErrorLog_*.txt");
                DateTime cutoffDate = DateTime.Now.AddDays(-DaysToKeep);

                foreach (string logFile in logFiles)
                {
                    try
                    {
                        // Extract date from filename (assuming format ErrorLog_YYYYMMDD.txt)
                        string fileName = Path.GetFileNameWithoutExtension(logFile);
                        string datePart = fileName.Substring("ErrorLog_".Length); // Get YYYYMMDD
                        if (DateTime.TryParseExact(datePart, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime fileDate))
                        {
                            if (fileDate < cutoffDate)
                            {
                                File.Delete(logFile);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log cleanup failure to console, continue with other files
                        Console.WriteLine($"Failed to process log file {logFile} for cleanup: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initialize logger: {ex.Message}");
            }
        }

        public static void Log(string message)
        {
            // try
            // {
            //     using StreamWriter writer = new(logFilePath, true);
            //     writer.WriteLine($"{DateTime.Now}: {message}");
            // }
            // catch (Exception ex)
            // {
            //     // Handle any exceptions that occur during logging
            //     Console.WriteLine($"Failed to write to log file: {ex.Message}");
            // }

            try
            {
                // Ensure Logs folder exists
                if (!Directory.Exists(LogFolderPath))
                {
                    Directory.CreateDirectory(LogFolderPath);
                }

                // Create filename with today's date (e.g., ErrorLog_20250321.txt)
                string dateString = DateTime.Now.ToString("yyyyMMdd");
                string logFileName = $"ErrorLog_{dateString}.txt";
                string logFilePath = Path.Combine(LogFolderPath, logFileName);

                // Prepare log entry with timestamp
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";

                // Append to today's log file (creates new file if it doesn't exist)
                File.AppendAllText(logFilePath, logEntry);
            }
            catch (Exception ex)
            {
                // Fallback logging to console if file logging fails
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
                Console.WriteLine($"Original error: {message}");
            }

        }

        public static void Log(Exception ex)
        {
            Log($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}");
        }
    }
}
