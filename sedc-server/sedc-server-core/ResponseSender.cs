using Azure;
using sedc_server_Server;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
namespace Sedc_Server_Try_One
{
    internal class ResponseSender
    {
        public ResponseSender()
        {
        }

        internal void Send(IResponse IResponse, NetworkStream NetworkStream)
        {
            var statusLine = string.Format("HTTP/1.1 {0} {1}\r\n", IResponse.Status, IResponse.Message);
            var separator = "\r\n";

            if (IResponse is TextResponse textResponse)
            {
                var body = textResponse.Message;
                var responseString = $"{statusLine}{separator}{body}";
                var responseBytes = Encoding.ASCII.GetBytes(responseString);
                NetworkStream.Write(responseBytes);
            }
            else if (IResponse is BinaryResponse binaryResponse)
            {
                var responseString = $"{statusLine}{separator}";
                var responseBytes = Encoding.ASCII.GetBytes(responseString);
                NetworkStream.Write(responseBytes);
                var body = binaryResponse.Message;
                NetworkStream.Write(responseBytes);
            }
            else
            {
                throw new ApplicationException($"Invalid response type {IResponse.GetType().FullName}");
            }
        }
    }
}