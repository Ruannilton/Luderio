using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Infrastructure.Contexts.Catalog.Database;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Catalog.Queries;
internal class GameIdExistsQuery : IGameIdExistsQuery
{
    private readonly CatalogDbContext dbContext;

    public GameIdExistsQuery(CatalogDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<bool> Execute(int id)
    {
        return await dbContext.Games.AnyAsync(x => x.BGGId == id);
    }
}
