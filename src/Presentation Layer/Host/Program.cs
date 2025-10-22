using Carter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using PresentationLayer.Host.Infrastructure.Dependency;
using System.Text.Json.Serialization.Metadata;
using PresentationLayer.Host.Infrastructure;

namespace PresentationLayer.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfigureHttpJsonOptions(o =>
            {
                o.SerializerOptions.TypeInfoResolver = JsonTypeInfoResolver.Combine(
                    AppJsonSerializerContext.Default
                );
            });

            builder.Services.AddProblemDetails();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSharedInfrastructure();

            builder.Services.RegisterAssembly();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Clean Architecture demo API Presentation Layer",
                    Description = "Clean Architecture demo Presentation Layer"
                });
            });

            builder.Services.AddCarter();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/swagger.json", "Clean Architecture demo API Presentation Layer");
                    c.DocumentTitle = "Clean Architecture Presentation Layer – Swagger";
                });
            }
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    var problem = new ProblemDetails
                    {
                        Status = 500,
                        Title = "Unexpected error",
                        Detail = "Something went wrong."
                    };
                    await context.Response.WriteAsJsonAsync(problem);
                });
            });

            app.UseStatusCodePages();
            app.MapCarter();

            app.Run();
        }
    }
}
