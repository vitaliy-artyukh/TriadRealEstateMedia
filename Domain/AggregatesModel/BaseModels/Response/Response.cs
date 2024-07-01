namespace Domain.AggregatesModel.BaseModels.Response;

public class Response<T> : BaseResponse
{
    public Response(T data, string message, bool isSuccess) : base(message, string.Empty, isSuccess)
    {
        Data = data;
    }
    
    public Response(T data) : base(string.Empty, string.Empty, true)
    {
        Data = data;
    }
    
    public T Data { get; set; }
}