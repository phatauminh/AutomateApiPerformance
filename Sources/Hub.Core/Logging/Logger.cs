using System;
using System.Text;

namespace Hub.Core.Logging
{
    public static class Logger
    {
        private static readonly object _lockObject = new object();
        public static StringBuilder LogTests = new StringBuilder();


        public static void LogInformation(string message)
        {
            lock (_lockObject)
            {
                try
                {
                    Console.WriteLine(message);
                    LogTests.AppendLine(message);
                }
                catch(Exception ex)
                {
                    // ignore
                }
            }
        }

        public static void LogWarning(string message)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                LogTests.AppendLine(message);
                Console.ResetColor();
            }
            catch
            {
                // ignore
            }
        }

        public static void LogError(string message)
        {
            lock (_lockObject)
            {
                try
                {
                    Console.Error.WriteLine(message);
                    LogTests.AppendLine(message);
                }
                catch
                {
                    // ignore
                }
            }
        }


    }
}
