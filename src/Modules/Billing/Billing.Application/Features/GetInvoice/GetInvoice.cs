using MediatR;
using Billing.Application.Models;

namespace Billing.Application.Features.GetInvoice;

// Query
public record GetInvoiceQuery(Guid Id) : IRequest<InvoiceReadModel?>;
