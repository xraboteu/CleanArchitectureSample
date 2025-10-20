using MediatR;
using VerticalSlice.Catalog.Application.Abstractions;
using VerticalSlice.Catalog.Domain;

namespace VerticalSlice.Catalog.Application.Features.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _repo;

    public CreateProductHandler(IProductRepository repo) => _repo = repo;

    public Task<Guid> Handle(CreateProductCommand request, CancellationToken ct)
    {
        var product = new Product(request.Name, request.Price);
        return _repo.AddAsync(product, ct);
    }
}
