using Domain.AggregatesModel.ContactAggregate.Models;

namespace Domain.AggregatesModel.ContactAggregate;

/// <summary>
/// Interface for interacting with contacts in the repository.
/// </summary>
public interface IContactRepository
{
    /// <summary>
    /// Retrieves a list of contacts based on the specified filter criteria.
    /// </summary>
    /// <param name="filter">The filter criteria.</param>
    /// <returns>A tuple containing the list of contacts and the total count.</returns>
    Task<(List<Contact> contacts, int totalCount)> GetAllAsync(ContactFilter filter);
    
    /// <summary>
    /// Retrieves a contact by its unique identifier.
    /// </summary>
    /// <param name="id">The ID of the contact.</param>
    /// <returns>The contact with the specified ID.</returns>
    Task<Contact> GetByIdAsync(int id);
    
    /// <summary>
    /// Adds a new contact to the repository.
    /// </summary>
    /// <param name="update">The contact data to add.</param>
    /// <returns>The added contact.</returns>
    Task<Contact> AddAsync(UpdateContact update);
    
    /// <summary>
    /// Updates an existing contact in the repository.
    /// </summary>
    /// <param name="id">The ID of the contact to update.</param>
    /// <param name="update">The updated contact data.</param>
    /// <returns>A task representing the update operation.</returns>
    Task UpdateAsync(int id, UpdateContact update);
    
    /// <summary>
    /// Deletes a contact from the repository by its ID.
    /// </summary>
    /// <param name="id">The ID of the contact to delete.</param>
    /// <returns>A task representing the delete operation.</returns>
    Task DeleteAsync(int id);
}