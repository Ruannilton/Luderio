using Luderia.Domain.Contexts.Payment.Abstraction.UseCases;
using Luderia.Domain.Contexts.Payment.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Luderia.Domain.Contexts.Payment;
public static class PaymentDependencyResolver
{
    public static void ResolvePaymentDependencies(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        services.AddScoped<ICreatePaymentRequestUseCase, CreatePaymentRequestUseCase>();
        services.AddScoped<IGetPaymentRequestUseCase, GetPaymentRequestUseCase>();
    }
}
