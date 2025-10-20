using MediatR;
using VerticalSlice.Billing.Application.Models;

namespace VerticalSlice.Billing.Application.Features.GetInvoice;

// Query
public record GetInvoiceQuery(Guid Id) : IRequest<InvoiceReadModel?>;
