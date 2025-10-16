using MediatR;
using Catalog.Application.Models;

namespace Catalog.Application.Features.GetProduct;

public record GetProductQuery(Guid Id) : IRequest<ProductReadModel?>;
