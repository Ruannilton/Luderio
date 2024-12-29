namespace Luderia.Presentation.Shared.Extensions;

using Luderia.Domain.Contexts.Catalog;
using Luderia.Domain.Contexts.Customers;
using Luderia.Infrastructure.Contexts.Catalog;
using Luderia.Infrastructure.Contexts.Customers;

public static class DependencyResolver
{
    public static void ResolveDependencies(this IHostApplicationBuilder builder)
    {
        builder.ResolveCatalogDomain();
        builder.ResolveCatalogInfrastructure();

        builder.ResolveCustomersDomain();
        builder.ResolveCustomerInfrastructure();
    }
}
