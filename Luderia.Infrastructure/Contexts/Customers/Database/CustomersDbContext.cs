using Luderia.Domain.Contexts.Customers.Models;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Customers.Database;
internal class CustomersDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public CustomersDbContext()
    {

    }
    public CustomersDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerDbConfiguration());
    }
}
