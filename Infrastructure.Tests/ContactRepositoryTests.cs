using AutoMapper;
using Domain.AggregatesModel.ContactAggregate.Models;
using Domain.AggregatesModel.ContactAggregate.Models.Db;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

[TestFixture]
public class ContactRepositoryTests
{
    private TriadRealEstateMediaContext _context;
    private Mock<IMapper> _mockMapper;
    private ContactRepository _repository;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<TriadRealEstateMediaContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new TriadRealEstateMediaContext(options);
        _mockMapper = new Mock<IMapper>();
        _repository = new ContactRepository(_context, _mockMapper.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _context?.Dispose();
    }

    [Test]
    public async Task GetByIdAsync_ShouldReturnContact()
    {
        // Arrange
        var contact = new DbContact { Id = 15, FirstName = "John", LastName = "Doe", Email = "john@example.com" };
        _context.Contacts.Add(contact);
        _context.SaveChanges();

        _mockMapper.Setup(m => m.Map<Contact>(It.IsAny<DbContact>())).Returns(new Contact());

        // Act
        var result = await _repository.GetByIdAsync(15);

        // Assert
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public async Task AddAsync_ShouldAddContact()
    {
        // Arrange
        var update = new UpdateContact { FirstName = "John", LastName = "Doe", Email = "john@example.com" };
        _mockMapper.Setup(m => m.Map<Contact>(It.IsAny<DbContact>())).Returns(new Contact());

        // Act
        var result = await _repository.AddAsync(update);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(_context.Contacts.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task UpdateAsync_ShouldUpdateContact()
    {
        // Arrange
        var update = new UpdateContact { FirstName = "John", LastName = "Doe", Email = "john@example.com" };
        var contact = new DbContact { Id = 11, FirstName = "John", LastName = "Doe", Email = "john@example.com" };
        _context.Contacts.Add(contact);
        _context.SaveChanges();

        // Act
        await _repository.UpdateAsync(11, update);

        // Assert
        var updatedContact = await _context.Contacts.FindAsync(11);
        Assert.That(updatedContact.Email, Is.EqualTo("john@example.com"));
    }

    [Test]
    public async Task DeleteAsync_ShouldDeleteContact()
    {
        // Arrange
        var contact = new DbContact
            { Id = 10, FirstName = "John", LastName = "Doe", Email = "john@example.com", DeletedAt = null };
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();

        // Act
        await _repository.DeleteAsync(10);

        // Assert
        var deletedContact = await _context.Contacts.FindAsync(10);
        Assert.That(deletedContact.DeletedAt, Is.Not.Null);
    }
}