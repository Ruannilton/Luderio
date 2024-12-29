using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
public interface IGetGameUseCase
{
    Task<Result<Game>> Execute(int id);
}