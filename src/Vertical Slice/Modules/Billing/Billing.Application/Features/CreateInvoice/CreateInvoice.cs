using MediatR;

namespace Billing.Application.Features.CreateInvoice;

// Command
public record CreateInvoiceCommand(Guid CustomerId, decimal Amount) : IRequest<Guid>;
