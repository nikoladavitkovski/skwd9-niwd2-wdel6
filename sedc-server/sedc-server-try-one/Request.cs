using Sedc.Server.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc_Server_Try_One
{
    internal class Request
    {
        public string Method { get; set; }

        public string Address { get; set; }

        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        private string HeaderRequest()
        {
            StringBuilder sb = new StringBuilder();
            return sb.ToString();
        }
    }
}
