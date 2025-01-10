using Luderia.Domain.Contexts.Orders.Models;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Orders.Database;
internal class OrderDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }

    public OrderDbContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new OrderDbConfiguration());
    }
}
