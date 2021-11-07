using Azure.Core;
using Sedc.Server.Core;
using sedc_server_Server;
using Sparrow.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Request = Sedc.Server.Core.Request;

namespace Sedc_Server_Try_One
{
    internal class RequestParser
    {
        internal static Request Parse(string input, ILogger logger)
        {
            var lines = input.Split("\r\n");
            var requestLine = lines[0];

            var rlRegex = new Regex(@"^([A-Z]+)\s\/(.*)\sHTTP\/1.1$");
            var rlMatch = rlRegex.Match(requestLine);

            var headerLines = lines.Skip(1).TakeWhile(line => line != "");
            var hlRegex = new Regex(@"^([a-zA-Z0-9-]+):\s(.+)$");
            var result = new Request
            {
                Method = rlMatch.Groups[1].Value,
                Address = UrlAddress.FromString(rlMatch.Groups[2].Value)
            };
            logger.Debug("Successfully parsed request line");

            foreach (var header in headerLines)
            {
                var hlMatch = hlRegex.Match(header);
                result.Headers.Add(hlMatch.Groups[1].Value, hlMatch.Groups[2].Value);
            }
            logger.Debug("Successfully parsed request headers");

            return result;
        }
    }
}
