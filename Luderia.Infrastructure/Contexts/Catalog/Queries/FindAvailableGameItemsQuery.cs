using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Infrastructure.Contexts.Catalog.Database;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Catalog.Queries;
internal class FindAvailableGameItemsQuery : IFindAvailableGameItemsQuery
{
    private readonly CatalogDbContext dbContext;

    public FindAvailableGameItemsQuery(CatalogDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IEnumerable<GameItem>> Execute(int gameId)
    {
        return await dbContext.GameItems.Where(x => x.GameId == gameId && x.Available == true).ToListAsync();
    }
}
