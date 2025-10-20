using MediatR;

namespace VerticalSlice.Catalog.Application.Features.CreateProduct;

public record CreateProductCommand(string Name, decimal Price) : IRequest<Guid>;
