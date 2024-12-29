using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Infrastructure.Contexts.Catalog.Database;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Catalog.Queries;

internal class GameTypeExistsQuery : IGameTypeExistsQuery
{
    private readonly CatalogDbContext dbContext;
    public GameTypeExistsQuery(CatalogDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<bool> Execute(string name)
    {
        return await dbContext.GameTypes.AnyAsync(x => x.Value == name);
    }
}
