using MediatR;
using VerticalSlice.Catalog.Application.Models;

namespace VerticalSlice.Catalog.Application.Features.GetProduct;

public record GetProductQuery(Guid Id) : IRequest<ProductReadModel?>;
