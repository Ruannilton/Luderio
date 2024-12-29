using Luderia.Domain.Contexts.Customers.Abstractions.UseCases;
using Luderia.Domain.Contexts.Customers.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Luderia.Domain.Contexts.Customers;
public static class CustomersDependencyResolver
{
    public static void ResolveCustomersDomain(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        services.AddScoped<IActivateCustomerUseCase, ActivateCustomerUseCase>();
        services.AddScoped<ICreateCustomerUseCase, CreateCustomerUseCase>();
        services.AddScoped<IUpdateCustomerUseCase, UpdateCustomerUseCase>();
        services.AddScoped<IDeactivateCustomerUseCase, DeactivateCustomerUseCase>();
        services.AddScoped<IUpdateCustomerAddressUseCase, UpdateCustomerAddressUseCase>();
        services.AddScoped<IUpdateCustomerUseCase, UpdateCustomerUseCase>();
    }
}
