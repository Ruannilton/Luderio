using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Infrastructure.Contexts.Catalog.Database;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Catalog.Queries;
internal class ListGameTypesQuery : IListGameTypesQuery
{
    private readonly CatalogDbContext catalogDbContext;

    public ListGameTypesQuery(CatalogDbContext catalogDbContext)
    {
        this.catalogDbContext = catalogDbContext;
    }
    public async Task<List<GameType>> Execute()
    {
        return await catalogDbContext.GameTypes.AsNoTracking().ToListAsync();
    }
}
