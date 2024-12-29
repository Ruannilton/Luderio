using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
public interface IFindAvailableGameItemsQuery
{
    Task<IEnumerable<GameItem>> Execute(int gameId);
}
