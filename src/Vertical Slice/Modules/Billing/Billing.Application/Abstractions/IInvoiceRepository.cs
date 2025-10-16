using Billing.Application.Models;
using Billing.Domain;

namespace Billing.Application.Abstractions;

public interface IInvoiceRepository
{
    Task<Guid> AddAsync(Invoice invoice, CancellationToken ct);
    Task<InvoiceReadModel?> GetAsync(Guid id, CancellationToken ct);
}
