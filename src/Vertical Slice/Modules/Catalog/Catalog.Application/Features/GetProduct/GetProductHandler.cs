using MediatR;
using VerticalSlice.Catalog.Application.Abstractions;
using VerticalSlice.Catalog.Application.Models;

namespace VerticalSlice.Catalog.Application.Features.GetProduct;

public class GetProductHandler : IRequestHandler<GetProductQuery, ProductReadModel?>
{
    private readonly IProductRepository _repo;

    public GetProductHandler(IProductRepository repo) => _repo = repo;

    public Task<ProductReadModel?> Handle(GetProductQuery request, CancellationToken ct)
        => _repo.GetAsync(request.Id, ct);
}
