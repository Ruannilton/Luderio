using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
using Luderia.Domain.Contexts.Catalog.UseCases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace Luderia.Domain.Contexts.Catalog;
public static class CatalogDependencyResolver
{
    public static void ResolveCatalogDomain(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddScoped<IAddGameTypeUseCase, AddGameTypeUseCase>();
        services.AddScoped<IAddGameUseCase, AddGameUseCase>();
        services.AddScoped<IRemoveGameUseCase, RemoveGameUseCase>();
        services.AddScoped<IAddTypeToGameUseCase, AddTypeToGameUseCase>();
        services.AddScoped<IRemoveGameTypeUseCase, RemoveGameTypeUseCase>();
        services.AddScoped<IRemoveTypeFromGameUseCase, RemoveTypeFromGameUseCase>();
        services.AddScoped<IUpdateGameUseCase, UpdateGameUseCase>();
        services.AddScoped<IGetGameUseCase, GetGameUseCase>();
        services.AddScoped<ISearchGameUseCase, SearchGameUseCase>();
        services.AddScoped<IListTypesUseCase, ListTypesUseCase>();

        services.AddScoped<IAddGameItemUseCase, AddGameItemUseCase>();
        services.AddScoped<IGetAvailableGameItemUseCase, GetAvailableGameItemUseCase>();
        services.AddScoped<IGetGameItemUseCase, GetGameItemUseCase>();
        services.AddScoped<IRentGameItemUseCase, BorrowGameItemUseCase>();
        services.AddScoped<IReturnGameItemUseCase, ReturnGameItemUseCase>();
        services.AddScoped<IAddDamageUseCase, AddDamageUseCase>();
        services.AddScoped<IRemoveDamageUseCase, RemoveDamageUseCase>();
        services.AddScoped<IUpdateDamageUseCase, UpdateDamageUseCase>();

    }
}
