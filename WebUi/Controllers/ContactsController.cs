using Domain.AggregatesModel.BaseModels.Response;
using Domain.AggregatesModel.ContactAggregate;
using Domain.AggregatesModel.ContactAggregate.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers;

/// <summary>
/// Controller for managing contacts.
/// </summary>
public class ContactsController : Controller
{
    /// <summary>
    /// The contact repository.
    /// </summary>
    private readonly IContactRepository _contactRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactsController"/> class.
    /// </summary>
    /// <param name="contactRepository">The contact repository.</param>
    public ContactsController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    /// <summary>
    /// Displays the contact list view.
    /// </summary>
    /// <returns>The view result for the contact list.</returns>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Retrieves a paginated list of contacts based on the specified filter.
    /// </summary>
    /// <param name="filter">The filter criteria.</param>
    /// <returns>A JSON response containing the list of contacts and the total count.</returns>
    public async Task<IActionResult> GetContacts(ContactFilter filter)
    {
        var (contacts, totalCount) = await _contactRepository.GetAllAsync(filter);
        return Ok(new PaginatedResponse<Contact>(contacts, totalCount));
    }

    /// <summary>
    /// Saves a contact. If the contact ID is 0, it adds a new contact; otherwise, it updates the existing contact.
    /// </summary>
    /// <param name="contact">The contact to save.</param>
    /// <returns>A JSON response indicating success or failure.</returns>
    [HttpPost]
    public async Task<IActionResult> Save(UpdateContact contact)
    {
        if (!ModelState.IsValid)
            return PartialView("_Edit", contact);

        if (contact.Id == 0)
            await _contactRepository.AddAsync(contact);
        else
            await _contactRepository.UpdateAsync(contact.Id, contact);

        return Json(new { success = true });
    }

    /// <summary>
    /// Retrieves the contact details for editing.
    /// </summary>
    /// <param name="id">The ID of the contact to edit.</param>
    /// <returns>The partial view with the contact details.</returns>
    [HttpGet]
    public async Task<IActionResult> Edit([FromRoute] int id)
    {
        if (id == 0)
            return PartialView("_Edit", new UpdateContact());

        var contact = await _contactRepository.GetByIdAsync(id);
        return PartialView("_Edit", new UpdateContact()
        {
            AddressName = contact.Address?.Name,
            AddressLatitude = contact.Address?.Latitude,
            AddressLongitude = contact.Address?.Longitude,
            Description = contact.Description,
            Email = contact.Email,
            Id = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            PhoneNumber = contact.PhoneNumber
        });
    }

    /// <summary>
    /// Deletes a contact by its ID.
    /// </summary>
    /// <param name="id">The ID of the contact to delete.</param>
    /// <returns>A JSON response indicating success or failure.</returns>
    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _contactRepository.DeleteAsync(id);
        return Ok();
    }
}