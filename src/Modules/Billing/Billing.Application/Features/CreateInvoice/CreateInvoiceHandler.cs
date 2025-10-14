using Billing.Application.Abstractions;
using Billing.Application.Features.Notifications;
using Billing.Domain;
using MediatR;

namespace Billing.Application.Features.CreateInvoice;

public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand, Guid>
{
    private readonly IInvoiceRepository _repo;
    private readonly IPublisher _publisher;

    public CreateInvoiceHandler(IInvoiceRepository repo, IPublisher publisher)
    {
        _repo = repo;
        _publisher = publisher;

    }

    public async Task<Guid> Handle(CreateInvoiceCommand request, CancellationToken ct)
    {
        var invoice = new Invoice(request.CustomerId, request.Amount);
        var id = await _repo.AddAsync(invoice, ct);

        // Publication de la notification
        await _publisher.Publish(new InvoiceCreated(
            InvoiceId: id,
            CustomerId: invoice.CustomerId,
            Amount: invoice.Amount
        ), ct);

        return id;
    }
}
