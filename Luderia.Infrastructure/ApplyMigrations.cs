using Luderia.Infrastructure.Contexts.Catalog.Database;
using Luderia.Infrastructure.Contexts.Customers.Database;
using Luderia.Infrastructure.Contexts.Orders.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Luderia.Infrastructure;
public static class ApplyMigrationsExtension
{
    public static void ApplyMigrations(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;

        var catalogDbContext = services.GetRequiredService<CatalogDbContext>();
        var customersDbContext = services.GetRequiredService<CustomersDbContext>();
        var orderDbContext = services.GetRequiredService<OrderDbContext>();

        catalogDbContext.Database.Migrate();
        customersDbContext.Database.Migrate();
        orderDbContext.Database.Migrate();
    }
}
