using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;


public interface IUpdateGameUseCase
{
    Task<Result<Game>> Execute(int bggId, UpdateGameMessage request);
}
