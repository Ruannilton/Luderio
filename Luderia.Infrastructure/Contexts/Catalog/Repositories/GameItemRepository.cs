using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Infrastructure.Contexts.Catalog.Database;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Catalog.Repositories;
internal class GameItemRepository : IGameItemRepository
{
    private readonly CatalogDbContext dbContext;

    public GameItemRepository(CatalogDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void AddGameItem(GameItem gameItem)
    {
        dbContext.GameItems.Add(gameItem);
    }

    public async Task<GameItem?> GetGameItem(int gameId)
    {
       return await dbContext.GameItems.FirstOrDefaultAsync(x => x.GameId == gameId);
    }
}
