using Domain.AggregatesModel.ContactAddressAggregate.Models.Db;
using Domain.AggregatesModel.ContactAggregate.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class TriadRealEstateMediaContext : DbContext
{
    public DbSet<DbContact> Contacts { get; set; }
    public DbSet<DbContactAddress> ContactAddresses { get; set; }

    public TriadRealEstateMediaContext(DbContextOptions<TriadRealEstateMediaContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbContact>(contact =>
        {
            contact.HasKey(c => c.Id);
            contact.HasOne(mc => mc.Address)
                .WithOne(mc => mc.Contact)
                .HasForeignKey<DbContactAddress>(mc => mc.ContactId)
                .OnDelete(DeleteBehavior.Cascade);
            contact.HasData(
                new DbContact
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "555-1234",
                    Email = "john.doe@example.com",
                    Description = "Friend from college",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new DbContact
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    PhoneNumber = "555-5678",
                    Email = "jane.smith@example.com",
                    Description = "Co-worker at TechCorp",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new DbContact
                {
                    Id = 3,
                    FirstName = "Michael",
                    LastName = "Johnson",
                    PhoneNumber = "555-8765",
                    Email = "michael.johnson@example.com",
                    Description = "Neighbor",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        });
        modelBuilder.Entity<DbContactAddress>(address =>
        {
            address.HasKey(a => a.Id);
            address.HasData(new DbContactAddress
            {
                Id = 1,
                ContactId = 1,
                Name = "The Big Ban",
                Latitude = 51.4966656,
                Longitude = -0.1258339,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }, new DbContactAddress
            {
                Id = 2,
                ContactId = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Longitude = -74.2914959,
                Latitude = 40.7484445,
                Name = "Empire State Building"
            });
        });
    }
}