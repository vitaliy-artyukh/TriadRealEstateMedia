namespace Domain.AggregatesModel.BaseModels;

public abstract class BaseEntitySoftDelete: BaseEntity, ISoftDelete
{
    public DateTime? DeletedAt { get; set; }
}