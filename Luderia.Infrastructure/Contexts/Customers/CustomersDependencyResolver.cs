using Luderia.Domain.Contexts.Customers.Abstractions;
using Luderia.Domain.Contexts.Customers.Abstractions.Queries;
using Luderia.Domain.Contexts.Customers.Abstractions.Repositories;
using Luderia.Infrastructure.Contexts.Customers.Database;
using Luderia.Infrastructure.Contexts.Customers.Queries;
using Luderia.Infrastructure.Contexts.Customers.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Luderia.Infrastructure.Contexts.Customers;

public static class CustomersDependencyResolver
{
    public static void ResolveCustomerInfrastructure(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        if (builder.Environment.IsDevelopment())
        {
            builder.AddNpgsqlDbContext<CustomersDbContext>("customerDb", null,
                options => options.UseNpgsql(npgOptions =>
                {
                    npgOptions.MigrationsAssembly(typeof(CustomersDbContext).Assembly.FullName);

                }).EnableSensitiveDataLogging(true)
            );
        }
        else
        {
            var connectionString = configuration["CustomerDbConnectionString"];
            services.AddDbContext<CustomersDbContext>(options =>
            {
                options.UseNpgsql(connectionString, npgOptions =>
                {
                    npgOptions.MigrationsAssembly(typeof(CustomersDbContext).Assembly.FullName);
                });
            });
        }

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerAlreadyExistsQuery, CustomerAlreadyExistsQuery>();
        services.AddScoped<IGetCustomerQuery, GetCustomerQuery>();
        services.AddScoped<ICustomerExistsQuery, CustomerExistsQuery>();
        services.AddScoped<ICustomersUnitOfWork, CustomerUnitOfWork>();

    }


}
