using Azure;
namespace Sedc_Server_Try_One
{
    internal class ResponseGenerator
    {
        public ResponseGenerator()
        {
        }

        internal Response GenerateResponse(Request request)
        {
            return new Response { Message = $"Hi, I'm a SEDC Server, nice to meet you. You have used the {request.Method} method",
                Status = 200
            };
        }
    }
}