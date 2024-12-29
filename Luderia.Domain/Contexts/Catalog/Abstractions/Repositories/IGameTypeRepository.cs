using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;

public interface IGameTypeRepository
{
    Task<GameType?> FindType(string type);
    void AddType(string type);
    void RemoveType(string type);
    Task<IEnumerable<GameType>> ListTypes();
}