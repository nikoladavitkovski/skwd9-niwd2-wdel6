
namespace sedc_server_Server
{
    internal interface IResponse<T> : IResponse
    {
        public T Message { get; set; }
    }

    public interface IResponse
    {
        public Status Status { get; set; }
        object Message { get; }
    }
}