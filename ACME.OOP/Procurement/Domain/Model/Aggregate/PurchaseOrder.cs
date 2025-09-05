using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurement.Domain.Model.Aggregate;

/// <summary>
/// represents a purchase order aggregate in the Procurement bounded context.
/// </summary>
/// <param name="orderNumber"><see cref="orderNumber"/> </param>
/// <param name="supplierId"></param>
/// <param name="orderDate"></param>
/// <param name="currency"></param>

public class PurchaseOrder (string orderNumber, SupplierId supplierId, DateTime orderDate, string currency)
{
    private readonly List<PurchaseOrderItem> _items = new();
    
    public string OrderNumber { get; } = orderNumber ?? throw new ArgumentNullException(nameof(orderNumber));
    public SupplierId SupplierId { get; } = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    public DateTime OrderDate { get; } = orderDate;
    public string Currency { get; } = string.IsNullOrWhiteSpace(currency) || currency.Length != 3 ? throw new ArgumentNullException(nameof(currency)) : currency;
    
    public IReadOnlyList<PurchaseOrderItem> Items => _items.AsReadOnly();

    /// <summary>
    /// Adds an item to the purchase order.
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    /// <param name="unitPriceAmount"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    
    public void AddItem(ProductId productId, int quantity, decimal unitPriceAmount)
    {
        ArgumentNullException.ThrowIfNull(nameof(productId));
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        if (unitPriceAmount <= 0) throw new ArgumentOutOfRangeException(nameof(unitPriceAmount));
        
        var unitPrice = new Money(unitPriceAmount, Currency);
        var item = new PurchaseOrderItem(productId, quantity, unitPrice);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Money calculateOrderTotal()
    {
        var totalAmount = _items.Sum(item=> item.CalculateItemTotal().Amount);
        return new Money(totalAmount, Currency);
    }
}