using VerticalSlice.Catalog.Application.Models;
using VerticalSlice.Catalog.Domain;

namespace VerticalSlice.Catalog.Application.Abstractions;

public interface IProductRepository
{
    Task<Guid> AddAsync(Product product, CancellationToken ct);
    Task<ProductReadModel?> GetAsync(Guid id, CancellationToken ct);
}
