using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc_server_Server
{
    internal class RequestProcessor
    {
        public IResponse Process(Request request)
        {
            throw new ApplicationException("The process is failed.");
            //return ApplicationException("Failed process");
            if (request != null) {
                string Message = $"Hello, <b><i>you're a SEDC server</i></b>, you're requesting the {request.Method} method" +
                    $"{request.Headers}";
            }
            return (IResponse)request; 
        }
    }
}
