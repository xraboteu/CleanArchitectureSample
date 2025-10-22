using Carter;
using PresentationLayer.Billing.Application.Features.CreateInvoice;
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
    
namespace PresentationLayer.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);

            builder.Services.AddCarter();

            builder.Services.AddValidatorsFromAssemblyContaining<CreateInvoiceValidator>();
            
            builder.Services.AddProblemDetails();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.MapCarter();

            app.Run();
        }
    }
}
