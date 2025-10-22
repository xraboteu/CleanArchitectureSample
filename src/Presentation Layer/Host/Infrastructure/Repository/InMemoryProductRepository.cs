using PresentationLayer.Catalog.Application.Abstractions;

namespace PresentationLayer.Host.Infrastructure.Repository;

public class InMemoryProductRepository : IProductRepository
{
    private readonly Dictionary<Guid, Catalog.Application.Models.ProductReadModel> _store = new();

    public Task<Guid> AddAsync(Catalog.Domain.Product product, CancellationToken ct)
    {
        var id = product.Id;
        _store[id] = new Catalog.Application.Models.ProductReadModel
        {
            Id = id,
            Name = product.Name,
            Price = product.Price
        };
        return Task.FromResult(id);
    }

    public Task<Catalog.Application.Models.ProductReadModel?> GetAsync(Guid id, CancellationToken ct)
        => Task.FromResult(_store.TryGetValue(id, out var val) ? val : null);
}