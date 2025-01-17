﻿using Sedc.Server.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc_server_Server
{
    public class ServerOptions
    {
        public int Port { get; set; }

        public List<string> AllowedMethods { get; set; }

        public IEnumerable<IRequestProcessor> Processors { get; set; }

        public ILogger Logger { get; set; }

        internal static ServerOptions MergeWithDefault(ServerOptions options)
        {
            if (options == null)
            {
                return ServerOptions.Default;
            }

            if (options.Port == default(int))
            {
                options.Port = ServerOptions.Default.Port;
            }

            if (options.AllowedMethods == default(List<string>))
            {
                options.AllowedMethods = ServerOptions.Default.AllowedMethods;
            }

            if (options.Processors == default(IRequestProcessor))
            {
                options.Processors = ServerOptions.Default.Processors;
            }

            if (options.Logger == default(ILogger))
            {
                options.Logger = ServerOptions.Default.Logger;
            }

            return options;
        }

        internal void RegisterProcessor(IRequestProcessor processor)
        {
            Processors = Processors.Prepend(processor);
        }

        internal static readonly ServerOptions Default = new ServerOptions
        {
            Port = 664, // The Neighbour of the Beast
            AllowedMethods = new List<string> { "GET", "POST" },
            Processors = new List<IRequestProcessor>{ new DefaultRequestProcessor() },
            Logger = new ConsoleLogger()
        };
    }
}
