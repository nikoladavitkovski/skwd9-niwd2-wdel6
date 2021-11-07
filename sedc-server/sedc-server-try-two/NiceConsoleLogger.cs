using sedc_server_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc_server_try_two
{
    class NiceConsoleLogger : ILogger
    {
        public LogLevel Level { get; set; }

        public void Log(string message, LogLevel level = LogLevel.Information)
        {
            if(level < Level)
            {
                return;
            }
            if(level < LogLevel.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if(level < LogLevel.Debug)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if(level < LogLevel.Information)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            if(level < LogLevel.Warning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
