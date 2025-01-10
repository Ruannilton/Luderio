using Luderia.Domain.Contexts.Orders.Abstractions;
using Luderia.Domain.Contexts.Orders.Abstractions.Repositories;
using Luderia.Infrastructure.Contexts.Orders.Database;
using Luderia.Infrastructure.Contexts.Orders.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Luderia.Infrastructure.Contexts.Orders;

public static class OrdersDependencyResolver
{
    public static void ResolveOrdersInfrastructure(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        if (builder.Environment.IsDevelopment())
        {
            builder.AddNpgsqlDbContext<OrderDbContext>("orderDb", null,
                options => options.UseNpgsql(npgOptions =>
                {
                    npgOptions.MigrationsAssembly(typeof(OrderDbContext).Assembly.FullName);

                }).EnableSensitiveDataLogging(true)
            );
        }
        else
        {
            var connectionString = configuration["OrderDbConnectionString"];
            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseNpgsql(connectionString, npgOptions =>
                {
                    npgOptions.MigrationsAssembly(typeof(OrderDbContext).Assembly.FullName);
                });
            });
        }

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderUnitOfWork, OrderUnitOfWork>();
    }
}
