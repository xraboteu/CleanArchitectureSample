using MediatR;
using PresentationLayer.Catalog.Application.Models;

namespace PresentationLayer.Catalog.Application.Features.GetProduct
{
    public record GetProductQuery(Guid Id) : IRequest<ProductReadModel?>;
}
