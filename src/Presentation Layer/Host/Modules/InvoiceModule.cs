using Carter;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Billing.Application.Features.CreateInvoice;
using PresentationLayer.Billing.Application.Features.GetInvoice;
using PresentationLayer.Billing.Application.Models;

namespace PresentationLayer.Host.Modules
{
    public class InvoiceModule : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            // Regroupe les endpoints de la feature avec un prefix clair et tags pour OpenAPI
            var group = app.MapGroup("/api/v1/invoices")
                .WithTags("Invoices");

            // GET /api/v1/invoices/{id}
            group.MapGet("/{id:int}", async Task<Results<Ok<InvoiceReadModel>, ProblemHttpResult>>
                    (Guid id, ISender sender, CancellationToken ct) =>
                {
                    var dto = await sender.Send(new GetInvoiceQuery(id), ct);
                    return dto is not null
                        ? TypedResults.Ok(dto)
                        : TypedResults.Problem(
                            title: "Invoice not found",
                            detail: $"Invoice {id} not found",
                            statusCode: StatusCodes.Status404NotFound);
                })
                .Produces<InvoiceReadModel>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status404NotFound);

            // POST /api/v1/invoices
            group.MapPost("/", async Task<Results<Created<Guid>, ValidationProblem>>
                    ([FromQuery] Guid customerId, decimal amount, ISender sender, CancellationToken ct) =>
                {
                    var id = await sender.Send(new CreateInvoiceCommand(customerId, amount), ct);
                    return TypedResults.Created($"/api/v1/invoices/{id}", id);
                })
                .AddEndpointFilter<FluentValidationFilter<CreateInvoiceCommand>>()
                .Produces<Guid>(StatusCodes.Status201Created)
                .ProducesValidationProblem();
        }
    }
}
