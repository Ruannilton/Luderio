using Luderia.Domain.Contexts.Customers.Abstractions.Queries;
using Luderia.Infrastructure.Contexts.Customers.Database;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Customers.Queries;

internal class CustomerExistsQuery : ICustomerExistsQuery
{
    private readonly CustomersDbContext dbContext;

    public CustomerExistsQuery(CustomersDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> Execute(Guid id)
    {
        return await dbContext.Customers.AnyAsync(c => c.Id == id);
    }
}
