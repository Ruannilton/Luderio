using Luderia.Domain.Contexts.Catalog.Abstractions;
using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Infrastructure.Contexts.Catalog.Database;
using Luderia.Infrastructure.Contexts.Catalog.Queries;
using Luderia.Infrastructure.Contexts.Catalog.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace Luderia.Infrastructure.Contexts.Catalog;
public static class CatalogDependencyResolver
{
    public static void ResolveCatalogInfrastructure(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        if (builder.Environment.IsDevelopment())
        {
            builder.AddNpgsqlDbContext<CatalogDbContext>("catalogDb", null,
                 options => options.UseNpgsql(npgOptions =>
                 {
                     npgOptions.MigrationsAssembly(typeof(CatalogDependencyResolver).Assembly.FullName);

                 }).EnableSensitiveDataLogging(true)
             );
        }
        else
        {
            var connectionString = configuration["CatalogDbConnectionString"];
            services.AddDbContext<CatalogDbContext>(options =>
            {
                options.UseNpgsql(connectionString, npgOptions =>
                {
                    npgOptions.MigrationsAssembly(typeof(CatalogDependencyResolver).Assembly.FullName);
                });
            });
        }


        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IGameTypeRepository, GameTypeRepository>();
        services.AddScoped<IGameItemRepository, GameItemRepository>();
        services.AddScoped<ICatalogUnitOfWork, CatalogUnitOfWork>();
        services.AddScoped<IGameIdExistsQuery, GameIdExistsQuery>();
        services.AddScoped<IGameTypeExistsQuery, GameTypeExistsQuery>();
        services.AddScoped<ISearchGameQuery, SearchGameQuery>();
        services.AddScoped<IListGameTypesQuery, ListGameTypesQuery>();
        services.AddScoped<IFindAvailableGameItemsQuery, FindAvailableGameItemsQuery>();

    }
}
