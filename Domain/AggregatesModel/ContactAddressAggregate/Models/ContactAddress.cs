using System.ComponentModel.DataAnnotations;
using Domain.AggregatesModel.BaseModels;

namespace Domain.AggregatesModel.ContactAddressAggregate.Models;

public class ContactAddress : BaseEntity
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public double Latitude { get; set; }
    
    [Required]
    public double Longitude { get; set; }
    
    public int ContactId { get; set; }
}
