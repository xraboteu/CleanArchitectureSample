namespace Billing.Application.Models;

public class InvoiceReadModel
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public decimal Amount { get; set; }
}
