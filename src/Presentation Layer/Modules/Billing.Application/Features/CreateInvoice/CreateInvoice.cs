using MediatR;

namespace PresentationLayer.Billing.Application.Features.CreateInvoice;

// Command
public record CreateInvoiceCommand(Guid CustomerId, decimal Amount) : IRequest<Guid>;
