using Domain.AggregatesModel.BaseModels;
using Domain.AggregatesModel.ContactAggregate.Models.Db;

namespace Domain.AggregatesModel.ContactAddressAggregate.Models.Db;

public class DbContactAddress : BaseEntity
{
    public string Name { get; set; }
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
    
    public int ContactId { get; set; }
    
    public DbContact Contact { get; set; }
}