using Sedc.Server.Core;
using Sedc_Server_Try_One;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc_server_Server
{
    public class TextResponse : IResponse<object>
    {
        public Status Status { get; set; }
        public object Message { get; set; }

        public UrlAddress Address { get; set; }

        public TextResponse()
        {
            Status = Status.OK;
        }
    }
}
