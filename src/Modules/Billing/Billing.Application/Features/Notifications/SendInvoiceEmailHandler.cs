using MediatR;
using Microsoft.Extensions.Logging;

namespace Billing.Application.Features.Notifications;

public sealed class SendInvoiceEmailHandler : INotificationHandler<InvoiceCreated>
{
    private readonly ILogger<SendInvoiceEmailHandler> _logger;
    // private readonly IEmailSender _email; // Exemple d’interface

    public SendInvoiceEmailHandler(ILogger<SendInvoiceEmailHandler> logger /*, IEmailSender email*/)
    {
        _logger = logger;
        // _email = email;
    }

    public async Task Handle(InvoiceCreated notification, CancellationToken ct)
    {
        // Ici appeler un service d’e-mail
        _logger.LogInformation("Invoice {InvoiceId} created for Customer {CustomerId} (Amount {Amount})",
            notification.InvoiceId, notification.CustomerId, notification.Amount);

        // await _email.SendAsync(..., ct);
        await Task.CompletedTask;
    }
}