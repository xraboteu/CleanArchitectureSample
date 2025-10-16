using Billing.Application.Abstractions;

namespace Host.Infrastructure.Repository;

public class InMemoryInvoiceRepository : IInvoiceRepository
{
    private readonly Dictionary<Guid, Billing.Application.Models.InvoiceReadModel> _store = new();

    public Task<Guid> AddAsync(Billing.Domain.Invoice invoice, CancellationToken ct)
    {
        var id = invoice.Id;
        _store[id] = new Billing.Application.Models.InvoiceReadModel
        {
            Id = id,
            CustomerId = invoice.CustomerId,
            Amount = invoice.Amount
        };
        return Task.FromResult(id);
    }

    public Task<Billing.Application.Models.InvoiceReadModel?> GetAsync(Guid id, CancellationToken ct)
        => Task.FromResult(_store.TryGetValue(id, out var val) ? val : null);
}