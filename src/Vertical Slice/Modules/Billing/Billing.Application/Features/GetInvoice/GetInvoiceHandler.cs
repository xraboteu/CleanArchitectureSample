using MediatR;
using VerticalSlice.Billing.Application.Abstractions;
using VerticalSlice.Billing.Application.Models;

namespace VerticalSlice.Billing.Application.Features.GetInvoice;

public class GetInvoiceHandler : IRequestHandler<GetInvoiceQuery, InvoiceReadModel?>
{
    private readonly IInvoiceRepository _repo;

    public GetInvoiceHandler(IInvoiceRepository repo) => _repo = repo;

    public Task<InvoiceReadModel?> Handle(GetInvoiceQuery request, CancellationToken ct)
        => _repo.GetAsync(request.Id, ct);
}
