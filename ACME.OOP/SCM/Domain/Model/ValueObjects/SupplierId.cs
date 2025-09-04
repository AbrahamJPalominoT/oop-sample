namespace ACME.OOP.SCM.Domain.Model.ValueObjects;

/// <summary>
/// Value object representing a Identifier in the Supply Chain Management bounded context.
/// </summary>
public record SupplierId
{
    public string Identifier { get; init; }

    /// <summary>
    /// Creates a new instance of <see cref="SupplierId"/>
    /// </summary>
    /// <param name="identifier">The unique identifier for the supplier.</param>
    /// <exception cref="ArgumentException">Thrown when the identifier is null or empty.</exception>
    public SupplierId(string identifier)
    {
        if (string.IsNullOrWhiteSpace(Identifier))
        {
            throw new ArgumentException("Supplier identifier cannot be null or empty.", nameof(identifier));
        }
        Identifier = identifier;;
    }
}