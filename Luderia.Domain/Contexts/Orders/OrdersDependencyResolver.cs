using Luderia.Domain.Contexts.Orders.Abstractions.UseCases;
using Luderia.Domain.Contexts.Orders.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Luderia.Domain.Contexts.Orders;
public static class OrdersDependencyResolver
{
    public static void ResolveOrdersDomain(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        services.AddScoped<ICreateOrderUseCase, CreateOrderUseCase>();
        services.AddScoped<IApproveOrderUseCase, ApproveOrderUseCase>();
        services.AddScoped<ICancelOrderUseCase, CancelOrderUseCase>();
    }
}
