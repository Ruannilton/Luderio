using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
public interface IGameItemRepository
{
    void AddGameItem(GameItem gameItem);
    Task<GameItem?> GetGameItem(int gameId);
}
