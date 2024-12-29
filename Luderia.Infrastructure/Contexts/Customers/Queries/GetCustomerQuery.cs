using Luderia.Domain.Contexts.Customers.Abstractions.Queries;
using Luderia.Domain.Contexts.Customers.Models;
using Luderia.Infrastructure.Contexts.Customers.Database;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Customers.Queries;

internal class GetCustomerQuery : IGetCustomerQuery
{
    private readonly CustomersDbContext dbContext;
    public GetCustomerQuery(CustomersDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<Customer?> Execute(Guid id)
    {
        return await dbContext.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}