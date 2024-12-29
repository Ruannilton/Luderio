using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
public interface IAddGameItemUseCase
{
    Task<Result> Execute(int gameId);
}

public interface IGetAvailableGameItemUseCase
{
    Task<Result<GameItem>> Execute(int gameId);
}

public interface IGetGameItemUseCase
{
    Task<Result<GameItem>> Execute(int gameItemId);
}

public interface IRentGameItemUseCase
{
    Task<Result> Execute(int gameItemId);
}

public interface IReturnGameItemUseCase
{
    Task<Result> Execute(int gameItemId);
}

public interface IAddDamageUseCase
{
    Task<Result> Execute(int gameItemId, string description);
}

public interface IRemoveDamageUseCase
{
    Task<Result> Execute(int gameItemId, int damageId);
}

public interface  IUpdateDamageUseCase
{
    Task<Result> Execute(int gameItemId, int damageId, string description);
}