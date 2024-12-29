using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
public interface IListTypesUseCase
{
    Task<List<GameType>> Execute();
}