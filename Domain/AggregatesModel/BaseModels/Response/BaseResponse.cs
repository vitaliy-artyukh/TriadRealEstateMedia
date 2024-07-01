namespace Domain.AggregatesModel.BaseModels.Response;

public class BaseResponse
{
    public string Message { get; set; } = string.Empty;
    
    public string InternalMessage { get; set; } = string.Empty;

    public string ErrorType { get; set; } = string.Empty;

    public bool IsSuccess { get; set; }

    public BaseResponse(string message, string errorType, bool isSuccess)
    {
        Message = message;
        ErrorType = errorType;
        IsSuccess = isSuccess;
    }

    public BaseResponse()
    {

    }

    public BaseResponse(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }
}