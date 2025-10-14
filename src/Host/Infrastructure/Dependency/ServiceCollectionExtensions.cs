using Billing.Application.Abstractions;
using Catalog.Application.Abstractions;
using Host.Infrastructure.Repository;
using System.Reflection;
using Billing.Application.Features.CreateInvoice;
using Catalog.Application.Features.CreateProduct;

namespace Host.Infrastructure.Dependency;

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