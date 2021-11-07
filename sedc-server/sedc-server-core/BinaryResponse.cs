using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc_server_Server
{
    public class BinaryResponse : IResponse<object>
    {
        public Status Status { get; set; }

        public object Message { get; set; }

        public BinaryResponse()
        {
            Status = Status.OK;
        }
    }
}
