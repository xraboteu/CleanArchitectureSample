using System.Reflection;
using VerticalSlice.Billing.Application.Abstractions;
using VerticalSlice.Billing.Application.Features.CreateInvoice;
using VerticalSlice.Catalog.Application.Abstractions;
using VerticalSlice.Catalog.Application.Features.CreateProduct;
using VerticalSlice.Host.Infrastructure.Repository;

namespace VerticalSlice.Host.Infrastructure.Dependency;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
    {
        // Implémentations in-memory pour démo
        services.AddSingleton<IInvoiceRepository, InMemoryInvoiceRepository>();
        services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        return services;
    }

    public static IServiceCollection RegisterAssembly(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CreateInvoiceCommand).Assembly);    // Billing.Application
            cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly);    // Catalog.Application
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());          // API/Host
        });
        return services;
    }
}