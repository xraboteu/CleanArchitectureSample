using MediatR;
using PresentationLayer.Billing.Application.Models;

namespace PresentationLayer.Billing.Application.Features.GetInvoice;

// Query
public record GetInvoiceQuery(Guid Id) : IRequest<InvoiceReadModel?>;
