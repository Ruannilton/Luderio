using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
public interface IListGameTypesQuery
{
    Task<List<GameType>> Execute();
}
