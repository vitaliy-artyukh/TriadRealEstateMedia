using Domain.AggregatesModel.BaseModels;
using Domain.AggregatesModel.ContactAddressAggregate.Models.Db;

namespace Domain.AggregatesModel.ContactAggregate.Models.Db;

public class DbContact : BaseEntitySoftDelete
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public string Description { get; set; }
    
    public virtual DbContactAddress Address { get; set; }
}