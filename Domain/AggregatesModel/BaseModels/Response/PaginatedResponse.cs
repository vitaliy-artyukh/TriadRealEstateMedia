namespace Domain.AggregatesModel.BaseModels.Response;

public class PaginatedResponse<T> : Response<IEnumerable<T>>
{
    public int TotalCount { get; set; }

    public PaginatedResponse(IEnumerable<T> data, int totalCount) : base(data, null,
        isSuccess: true)
    {
        TotalCount = totalCount;
    }
}