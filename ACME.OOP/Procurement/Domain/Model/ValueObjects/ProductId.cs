namespace ACME.OOP.Procurement.Domain.Model.ValueObjects;

public record ProductId
{
    public Guid Id { get; init; }

    public ProductId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Product ID cannot be an empty GUID.", nameof(id));
        Id = id;
    }
    
    public static ProductId NewId() => new (Guid.NewGuid());
}