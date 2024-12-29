using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
public interface ISearchGameUseCase
{
    Task<List<GameHeader>> Execute(SearchGameMessage criteria);
}