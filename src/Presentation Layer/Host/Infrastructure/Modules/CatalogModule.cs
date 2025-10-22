using Carter;
using Carter.OpenApi;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using PresentationLayer.Catalog.Application.Features.CreateProduct;
using PresentationLayer.Catalog.Application.Features.GetProduct;
using PresentationLayer.Catalog.Application.Models;
using PresentationLayer.Host.Infrastructure.Modules.Dtos;

namespace PresentationLayer.Host.Infrastructure.Modules;

public class CatalogModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/catalog")
            .WithTags("Catalog")
            .IncludeInOpenApi();

        group.MapPost("/products", async (CreateProductDto product, ISender sender, CancellationToken ct) =>
            {
                var generatedId = await sender.Send(new CreateProductCommand(product.Name, product.Price), ct);
                var response = new CreateProductResponseDto(generatedId);
                return Results.Created($"/catalog/products/{response.Id}", response);
            }).ProducesValidationProblem()
            .IncludeInOpenApi();

        group.MapGet("/products/{id:guid}", async Task<Results<Ok<ProductReadModel>, ProblemHttpResult>> 
                (Guid id, ISender sender, CancellationToken ct) =>
            {
                var product = await sender.Send(new GetProductQuery(id), ct);

                return product is not null
                    ? TypedResults.Ok(product)
                    : TypedResults.Problem(
                        title: "product not found",
                        detail: $"product {id} not found",
                        statusCode: StatusCodes.Status404NotFound);
            }).ProducesValidationProblem()
            .IncludeInOpenApi();
    }
}