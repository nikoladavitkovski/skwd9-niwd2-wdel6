﻿using Azure.Core;
using Sedc.Server.Core;
using sedc_server_Server;
using System;
using Request = Sedc.Server.Core.Request;

namespace sedc_server_try_two
{
    class MyRequestProcessor : IRequestProcessor
    {
        public IResponse Process(Request request, ILogger logger)
        {
            return new TextResponse
            {
                Message = $@"
<html>
    <head>
        <title>Custom SEDC Server</title>
    </head>
    <body>
        Hi, I'm a <b>Custom SEDC Server</b> and <i>I don't like you</i>! You used the {request.Method} method on the {request.Address} URL
    </body>
</html>",
                Status = Status.OK
            };
        }

        public IResponse Process(Azure.Core.Request request, ILogger logger)
        {
            throw new NotImplementedException();
        }

        public bool ShouldProcess(Request request)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var logger = new CompositeLogger();
            logger.AddLogger(new NiceConsoleLogger { Level = LogLevel.Debug });
            logger.AddLogger(new FileLogger("log.txt"));

            try
            {
                Server server = new Server(new ServerOptions
                {
                    Port = 668,
                    Logger = logger
                });
                server.RegisterProcessor(new FileRequestProcessor("public-sedc"));
                server.RegisterProcessor(new ApiRequestProcessor());
                server.Start();
            }
            catch (ApplicationException aex)
            {
                var oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Application Exception: ");
                Console.WriteLine(aex.Message);
                Console.ForegroundColor = oldColor;
            }
        }
    }
}
