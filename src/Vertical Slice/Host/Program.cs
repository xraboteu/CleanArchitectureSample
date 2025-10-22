using Microsoft.OpenApi.Models;
using VerticalSlice.Host.Infrastructure.Dependency;
using VerticalSlice.Host.Infrastructure.Routing;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSharedInfrastructure(); 
builder.Services.RegisterAssembly();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Clean Architecture demo API Vertical Slice",
        Version = "v1",
        Description = "Clean Architecture demo Vertical Slice"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture demo");
        c.DocumentTitle = "Clean Architecture demo – Swagger";
    });
}

app.MapGet("/", () => new { name = "Clean Architecture Sample", version = "1.0", modules = new[] { "Billing", "Catalog" } });

// Endpoints de modules
app.MapBillingEndpoints();
app.MapCatalogEndpoints();

app.Run();  
