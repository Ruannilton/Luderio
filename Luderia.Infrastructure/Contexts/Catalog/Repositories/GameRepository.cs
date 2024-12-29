using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Infrastructure.Contexts.Catalog.Database;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Catalog.Repositories;

internal class GameRepository : IGameRepository
{
    private readonly CatalogDbContext _context;

    public GameRepository(CatalogDbContext context)
    {
        _context = context;
    }

    public void Add(Game game)
    {
        _context.Games.Add(game);
    }

    public async Task<Game?> Find(int bggId)
    {
        var game = await _context.Games
            .Include(g => g.Types)
            .FirstOrDefaultAsync(g => g.BGGId == bggId);
        return game;
    }

    public void Remove(Game game)
    {
        _context.Remove(game);
    }



}
