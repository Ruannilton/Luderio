using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Infrastructure.Contexts.Catalog.Database;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Catalog.Repositories;

internal class GameTypeRepository : IGameTypeRepository
{
    private readonly CatalogDbContext _context;

    public GameTypeRepository(CatalogDbContext context)
    {
        _context = context;
    }

    public void AddType(string type)
    {
        var newType = new GameType()
        {
            Value = type
        };

        _context.GameTypes.Add(newType);
    }

    public async Task<GameType?> FindType(string type)
    {
        var foundType = await _context.GameTypes.FirstOrDefaultAsync(t => t.Value == type);
        return foundType;
    }

    public async Task<IEnumerable<GameType>> ListTypes()
    {
        var types = await _context.GameTypes.ToListAsync();
        return types;
    }

    public void RemoveType(string type)
    {
        _context.GameTypes.Where(x => x.Value == type).ExecuteDelete();
    }
}