using Luderia.Domain.Contexts.Catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Catalog.Database;

internal class CatalogDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<GameType> GameTypes { get; set; }
    public DbSet<GameItem> GameItems { get; set; }
    public CatalogDbContext() { }

    public CatalogDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new GameDbConfiguration());
        modelBuilder.ApplyConfiguration(new GameTypeDbConfiguration());
        modelBuilder.ApplyConfiguration(new GameItemDbConfiguration());
    }
}
