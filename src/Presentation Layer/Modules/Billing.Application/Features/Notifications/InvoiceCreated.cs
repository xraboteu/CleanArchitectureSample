using MediatR;

namespace PresentationLayer.Billing.Application.Features.Notifications;

public sealed record InvoiceCreated(Guid InvoiceId, Guid CustomerId, decimal Amount) : INotification;