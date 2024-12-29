using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
public interface ISearchGameQuery
{
    Task<IEnumerable<GameHeader>> Execute(SearchGameMessage searchGameMessage);
}
