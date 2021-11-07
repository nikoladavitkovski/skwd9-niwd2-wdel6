using System;

namespace sedc_server_Server
{
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger()
        {
            Level = LogLevel.Information;
        }

        public LogLevel Level { get; set; }

        public void Log(string message, LogLevel level = LogLevel.Information)
        {
            if(level >= level)
            {
                Console.WriteLine($"[{level.ToString().ToUpperInvariant()}] {message}");
            }
        }
    }
}