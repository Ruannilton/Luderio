namespace Luderia.Presentation.Shared.Extensions;

using Luderia.Domain.Contexts.Catalog;
using Luderia.Domain.Contexts.Customers;
using Luderia.Domain.Contexts.Orders;
using Luderia.Infrastructure.Contexts.Catalog;
using Luderia.Infrastructure.Contexts.Customers;
using Luderia.Infrastructure.Contexts.Orders;

public static class DependencyResolver
{
    public static void ResolveDependencies(this IHostApplicationBuilder builder)
    {
        builder.ResolveCatalogDomain();
        builder.ResolveCatalogInfrastructure();
        builder.ResolveOrdersDomain();

        builder.ResolveCustomersDomain();
        builder.ResolveCustomerInfrastructure();
        builder.ResolveOrdersInfrastructure();
    }
}
