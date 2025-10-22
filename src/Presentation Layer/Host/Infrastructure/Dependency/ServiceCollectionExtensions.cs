using PresentationLayer.Billing.Application.Abstractions;
using PresentationLayer.Billing.Application.Features.CreateInvoice;
using PresentationLayer.Catalog.Application.Abstractions;
using PresentationLayer.Catalog.Application.Features.CreateProduct;
using System.Reflection;
using FluentValidation;
using PresentationLayer.Host.Infrastructure.Repository;

namespace PresentationLayer.Host.Infrastructure.Dependency
{
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
            services.AddValidatorsFromAssemblyContaining<CreateInvoiceValidator>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateInvoiceCommand).Assembly);    // Billing.Application
                cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly);    // Catalog.Application
                //cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());          // API/Host
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
            return services;
        }
    }
}
