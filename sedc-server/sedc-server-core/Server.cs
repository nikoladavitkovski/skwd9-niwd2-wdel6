using Raven.Embedded;
using Sedc.Server.Core;
using Sedc_Server_Try_One;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace sedc_server_Server
{
    public class Server
    {
        private readonly ServerOptions options;
        public Server(ServerOptions options = null)
        {
            options = ServerOptions.MergeWithDefault(options);
            this.options = options;
        }

        public void RegisterProcessor(IRequestProcessor requestProcessor) => this.options.RegisterProcessor(requestProcessor);

        public void Start()
        {
            var address = IPAddress.Loopback;
            var port = options.Port;
            TcpListener listener = new TcpListener(address, port);
            listener.Start();
            options.Logger.Info($"Started listening on port {port}");

            while (true)
            {
                // Accept the connection
                options.Logger.Debug($"Waiting for tcp client");
                var client = listener.AcceptTcpClient();
                options.Logger.Debug($"Accepted tcp client");
                var stream = client.GetStream();

                // Process the request
                var reader = new RequestReader(options.Logger);
                var request = reader.ReadRequest(stream);

                // Generate a response based on the request
                var generator = new ResponseGenerator(options.Processors, options.Logger);
                var response = generator.GenerateResponse(request);

                // Sending the response
                var sender = new ResponseSender();
                sender.Send((IResponse)response, stream);

                // close the connection
                client.Close();
            }
        }
    }
}
