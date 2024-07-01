using Domain.AggregatesModel.BaseModels;
using Domain.AggregatesModel.ContactAddressAggregate.Models;

namespace Domain.AggregatesModel.ContactAggregate.Models;

public class Contact : BaseEntity
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public string Description { get; set; }
    
    public ContactAddress Address { get; set; }
}