using AutoMapper;
using Domain.AggregatesModel.ContactAddressAggregate.Models.Db;
using Domain.AggregatesModel.ContactAggregate;
using Domain.AggregatesModel.ContactAggregate.Models;
using Domain.AggregatesModel.ContactAggregate.Models.Db;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <inheritdoc />
public class ContactRepository : IContactRepository
{
    private readonly TriadRealEstateMediaContext _dataContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactRepository"/> class.
    /// </summary>
    /// <param name="dataContext">The database context for interacting with contacts.</param>
    /// <param name="mapper">The mapper for mapping between DTOs and database entities.</param>
    public ContactRepository(TriadRealEstateMediaContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<(List<Contact> contacts, int totalCount)> GetAllAsync(ContactFilter filter)
    {
        var query = _dataContext.Contacts
            .Where(ci => ci.DeletedAt == null);
        if (!string.IsNullOrWhiteSpace(filter.FirstName))
            query = query.Where(q => q.FirstName.Contains(filter.FirstName));

        if (!string.IsNullOrWhiteSpace(filter.LastName))
            query = query.Where(q => q.LastName.Contains(filter.LastName));

        if (!string.IsNullOrWhiteSpace(filter.Email))
            query = query.Where(q => q.Email.Contains(filter.Email));

        if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
            query = query.Where(q => q.PhoneNumber.Contains(filter.PhoneNumber));

        var totalCount = await query.CountAsync();
        var dbContacts = await query
            .Skip(filter.Skip)
            .Take(filter.Take)
            .ToListAsync();
        var contacts = _mapper.Map<List<Contact>>(dbContacts);
        return (contacts, totalCount);
    }

    /// <inheritdoc />
    public async Task<Contact> GetByIdAsync(int id)
    {
        var entity = await _dataContext.Contacts
            .Include(q => q.Address)
            .Where(ci => ci.DeletedAt == null)
            .Where(ci => ci.Id == id)
            .FirstOrDefaultAsync();

        if (entity is null)
            throw new NotFoundException(nameof(Contact), id);

        return _mapper.Map<Contact>(entity);
    }
    
    /// <inheritdoc />
    public async Task<Contact> AddAsync(UpdateContact update)
    {
        var result = await _dataContext.Contacts.AddAsync(new DbContact
        {
            FirstName = update.FirstName,
            LastName = update.LastName,
            Description = update.Description,
            PhoneNumber = update.PhoneNumber,
            Email = update.Email,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Address = PrepareDbAddressForSave(update)
        });

        await _dataContext.SaveChangesAsync();

        return _mapper.Map<Contact>(result.Entity);
    }

    /// <inheritdoc />
    public async Task UpdateAsync(int id, UpdateContact update)
    {
        var entity = await _dataContext.Contacts
            .Include(c => c.Address)
            .Where(ci => ci.DeletedAt == null)
            .Where(ci => ci.Id == id)
            .FirstOrDefaultAsync();

        if (entity is null)
            throw new NotFoundException(nameof(Contact), id);

        entity.FirstName = update.FirstName;
        entity.LastName = update.LastName;
        entity.Email = update.Email;
        entity.PhoneNumber = update.PhoneNumber;
        entity.Description = update.Description;
        entity.UpdatedAt = DateTime.UtcNow;
        if (entity.Address != null)
        {
            // update existed contact address
            if (!string.IsNullOrEmpty(update.AddressName))
            {
                entity.Address.Name = update.AddressName;
                entity.Address.Latitude = update.AddressLatitude ?? 0;
                entity.Address.Longitude = update.AddressLongitude ?? 0;
            }
            // remove existed contact address 
            else
            {
                _dataContext.ContactAddresses.Remove(entity.Address);
            }
        }
        // add new address if needed 
        else if (!string.IsNullOrEmpty(update.AddressName))
        {
            entity.Address = PrepareDbAddressForSave(update);
        }

        await _dataContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int id)
    {
        var entity = await _dataContext.Contacts
            .Where(ci => ci.DeletedAt == null)
            .Where(ci => ci.Id == id)
            .FirstOrDefaultAsync();

        if (entity is null)
            return;

        entity.DeletedAt = DateTime.UtcNow;
        await _dataContext.SaveChangesAsync();
    }
    
    private DbContactAddress PrepareDbAddressForSave(UpdateContact update)
    {
        var newAddress = update.AddressName == null
            ? null
            : new DbContactAddress()
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Latitude = update.AddressLatitude ?? 0,
                Longitude = update.AddressLongitude ?? 0,
                Name = update.AddressName
            };
        return newAddress;
    }
}