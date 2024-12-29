using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;


public interface IGameRepository
{
    void Add(Game game);
    void Remove(Game game);
    Task<Game?> Find(int bggId);
}
