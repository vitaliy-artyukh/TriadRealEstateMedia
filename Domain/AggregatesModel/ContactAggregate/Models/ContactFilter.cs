using Domain.AggregatesModel.BaseModels;

namespace Domain.AggregatesModel.ContactAggregate.Models;

public class ContactFilter : PaginationRequest
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
}