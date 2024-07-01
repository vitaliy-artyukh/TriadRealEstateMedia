namespace Domain.AggregatesModel.BaseModels;

public interface ISoftDelete
{
    public DateTime? DeletedAt { get; set; }
}