using PresentationLayer.Catalog.Domain;
using PresentationLayer.Catalog.Application.Models;

namespace PresentationLayer.Catalog.Application.Abstractions
{
    public interface IProductRepository
    {
        Task<Guid> AddAsync(Product product, CancellationToken ct);
        Task<ProductReadModel?> GetAsync(Guid id, CancellationToken ct);
    }
}
