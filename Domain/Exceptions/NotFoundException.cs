namespace Domain.Exceptions;

/// <summary>
/// Exception thrown when a requested entity is not found.
/// </summary>
public class NotFoundException : Exception
{
    private const string NotFound = "Not Found";
    
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class for an entity with a specific ID.
    /// </summary>
    /// <param name="entityName">The name of the entity.</param>
    /// <param name="id">The ID of the entity (optional).</param>
    public NotFoundException(string entityName, int? id) : base(string.Concat(entityName,
        id.HasValue ? id.Value.ToString().PadLeft(id.Value.ToString().Length + 1) : string.Empty,
        "Not Found".PadLeft(NotFound.Length + 1)))
    {
    }

    public NotFoundException(string entityName, string value = null) : base(string.Concat(entityName,
        string.IsNullOrWhiteSpace(value) ? string.Empty : value.PadLeft(value.Length + 1),
        NotFound.PadLeft(NotFound.Length + 1)))
    {
    }

    public NotFoundException(string entityName) : base(string.Concat(entityName,
        string.Empty,
        NotFound.PadLeft(NotFound.Length + 1)))
    {
    }
}