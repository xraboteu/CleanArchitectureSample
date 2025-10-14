using Catalog.Application.Models;
using Catalog.Domain;

namespace Catalog.Application.Abstractions;

public interface IProductRepository
{
    Task<Guid> AddAsync(Product product, CancellationToken ct);
    Task<ProductReadModel?> GetAsync(Guid id, CancellationToken ct);
}
