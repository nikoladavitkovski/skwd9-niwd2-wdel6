using Sedc.Server.Core;
using sedc_server_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc_Server_Try_One
{
    internal class Response : IResponse
    {
        public string Message { get; set; }

        public UrlAddress Address { get; set; }

        public Status Status { get; set; }

        object IResponse.Message => throw new NotImplementedException();

        public Response()
        {
            Status = Status.ServerError;
        }

    }
}
