using PresentationLayer.Billing.Application.Models;
using PresentationLayer.Billing.Domain;

namespace PresentationLayer.Billing.Application.Abstractions;

public interface IInvoiceRepository
{
    Task<Guid> AddAsync(Invoice invoice, CancellationToken ct);
    Task<InvoiceReadModel?> GetAsync(Guid id, CancellationToken ct);
}
