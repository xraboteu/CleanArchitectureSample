using Billing.Application.Features.CreateInvoice;
using Billing.Application.Features.GetInvoice;
using Catalog.Application.Features.CreateProduct;
using Catalog.Application.Features.GetProduct;
using MediatR;

namespace Host.Infrastructure.Routing;

public static class Endpoints
{
    public static IEndpointRouteBuilder MapBillingEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/billing");

        group.MapPost("/invoices", async (CreateInvoiceCommand cmd, ISender sender, CancellationToken ct) =>
        {
            var id = await sender.Send(cmd, ct);
            return Results.Created($"/billing/invoices/{id}", new { id });
        });

        group.MapGet("/invoices/{id:guid}", async (Guid id, ISender sender, CancellationToken ct) =>
        {
            var invoice = await sender.Send(new GetInvoiceQuery(id), ct);
            return invoice is not null ? Results.Ok(invoice) : Results.NotFound();
        });

        return group;
    }

    public static IEndpointRouteBuilder MapCatalogEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/catalog");

        group.MapPost("/products", async (CreateProductCommand cmd, ISender sender, CancellationToken ct) =>
        {
            var id = await sender.Send(cmd, ct);
            return Results.Created($"/catalog/products/{id}", new { id });
        });

        group.MapGet("/products/{id:guid}", async (Guid id, ISender sender, CancellationToken ct) =>
        {
            var product = await sender.Send(new GetProductQuery(id), ct);
            return product is not null ? Results.Ok(product) : Results.NotFound();
        });

        return group;
    }
}