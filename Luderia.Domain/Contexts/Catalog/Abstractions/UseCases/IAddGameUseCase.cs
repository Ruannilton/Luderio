using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
public interface IAddGameUseCase
{
    Task<Result<Game>> Execute(AddGameMessage game);
}
