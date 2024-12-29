using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Infrastructure.Contexts.Catalog.Database;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Catalog.Queries;

internal class SearchGameQuery : ISearchGameQuery
{
    private readonly CatalogDbContext dbContext;

    public SearchGameQuery(CatalogDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IEnumerable<GameHeader>> Execute(SearchGameMessage criteria)
    {
        var query = dbContext.Games.AsQueryable().AsNoTracking();

        if (criteria.Name is not null)
        {
            query = query.Where(g => g.Name.Contains(criteria.Name));
        }

        if (criteria.Types is { Count: > 0 })
        {
            foreach (var type in criteria.Types)
            {
                query = query.Where(g => g.Types.Any(x => x.Value == type));
            }
        }

        if (criteria.MinPlayers is not null)
        {
            query = query.Where(g => g.MinPlayers >= criteria.MinPlayers);
        }

        if (criteria.MaxPlayers is not null)
        {
            query = query.Where(g => g.MaxPlayers <= criteria.MaxPlayers);
        }

        if (criteria.MinAge is not null)
        {
            query = query.Where(g => g.MinAge >= criteria.MinAge);
        }

        if (criteria.Duration is not null)
        {
            query = query.Where(g => g.Duration <= criteria.Duration);
        }

        var gameHeaders = query.Select(x => new GameHeader()
        {
            BGGId = x.BGGId,
            Name = x.Name
        });

        var headers = await gameHeaders.ToListAsync();

        return headers;
    }
}