using System;
using System.Collections.Generic;

namespace sedc_server_Server
{
    public class CompositeLogger : ILogger
    {
        private List<ILogger> loggers = new List<ILogger>();
        public LogLevel Level { get; set; }

        public CompositeLogger()
        {
            Level = LogLevel.Information;
        }

        public void AddLogger(ILogger logger)
        {
            loggers.Add(logger);
        }

        public void Log(string message, LogLevel level = LogLevel.Information)
        {
            foreach (var logger in loggers)
            {
                logger.Log(message, level);
            }
        }
    }
}