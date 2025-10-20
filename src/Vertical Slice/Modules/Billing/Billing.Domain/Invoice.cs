namespace VerticalSlice.Billing.Domain;

public class Invoice
{
    public Guid Id { get; }
    public Guid CustomerId { get; }
    public decimal Amount { get; }

    public Invoice(Guid customerId, decimal amount)
    {
        if (customerId == Guid.Empty) throw new ArgumentException("CustomerId invalide");
        if (amount <= 0) throw new ArgumentException("Amount doit être > 0");

        Id = Guid.NewGuid();
        CustomerId = customerId;
        Amount = amount;
    }
}
