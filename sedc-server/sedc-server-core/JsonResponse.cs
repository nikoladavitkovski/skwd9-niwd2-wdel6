using sedc_server_Server;

namespace Sedc.Server.Core
{
    public class JsonResponse<T> : JsonResponse, IResponse<T>
    {
        public T Message { get; set; }

        public override string GetMessagePayload()
        {
            return "{ \"value\": 4 }";
        }
    }

    public abstract class JsonResponse : IResponse
    {
        public Status Status { get; set; }

        public object Message => throw new System.NotImplementedException();

        public abstract string GetMessagePayload();

        public JsonResponse()
        {
            Status = Status.OK;
        }
    }
}