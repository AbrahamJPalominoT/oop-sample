namespace ACME.OOP.Procurement.Domain.Model.ValueObjects;

/// <summary>
/// Creates a new instance of <see cref="ProductId"/> with the specified GUID.
/// </summary>
/// <param name="id">The <see cref="Guid"/> value for the product identifier.</param>
/// <exception cref="ArgumentException">Thrown when the provided GUID is empty.</exception>
public record ProductId
{
    public Guid Id { get; init; }

    public ProductId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Product ID cannot be an empty GUID.", nameof(id));
        Id = id;
    }
    /// <summary>
    /// Generates a new <see cref="ProductId"/> instance with a unique GUID.
    /// </summary>
    /// <returns>A new instance of <see cref="ProductId"/>.</returns>
    public static ProductId NewId() => new (Guid.NewGuid());
    
    /// <summary>
    /// Returns the string representation of the <see cref="ProductId"/>.
    /// </summary>
    /// <returns>A string representing the GUID of the product identifier.</returns>
    public override string ToString() => Id.ToString();
}