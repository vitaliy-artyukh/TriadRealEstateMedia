namespace Domain.AggregatesModel.BaseModels;

public class PaginationRequest
{
    public int Skip { get; set; } = 0;
    
    public int Take { get; set; } = 10_000;
}