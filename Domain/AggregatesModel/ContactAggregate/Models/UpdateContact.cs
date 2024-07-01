using System.ComponentModel.DataAnnotations;

namespace Domain.AggregatesModel.ContactAggregate.Models;

public class UpdateContact
{
    public int Id { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    public string Description { get; set; }
    
    public string AddressName { get; set; }
    
    public double? AddressLatitude { get; set; }
    
    public double? AddressLongitude { get; set; }
}