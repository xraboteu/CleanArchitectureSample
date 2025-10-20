using VerticalSlice.Billing.Application.Models;
using VerticalSlice.Billing.Domain;

namespace VerticalSlice.Billing.Application.Abstractions;

public interface IInvoiceRepository
{
    Task<Guid> AddAsync(Invoice invoice, CancellationToken ct);
    Task<InvoiceReadModel?> GetAsync(Guid id, CancellationToken ct);
}
