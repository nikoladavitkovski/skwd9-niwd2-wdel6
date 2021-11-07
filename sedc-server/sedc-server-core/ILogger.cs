using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace sedc_server_Server
{
    public enum LogLevel
    {
        Debug,
        Information,
        Warning,
        Error,
        Critical
    }

    public interface ILogger
    {
        public LogLevel Level { get; set; }

        void Log(string message, LogLevel level = LogLevel.Information);

        void LogException(Exception ex, LogLevel level = LogLevel.Error)
        {
            Log(ex.Message, level);
        }
        void Debug(string message) => Log(message, LogLevel.Debug);
        void Info(string message) => Log(message, LogLevel.Information);

        void Warning(string message) => Log(message, LogLevel.Warning);

        void Error(string message) => Log(message, LogLevel.Error);

        void Critical(string message) => Log(message, LogLevel.Critical);
    }
}
