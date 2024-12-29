using Luderia.Domain.Contexts.Customers.Abstractions.Repositories;
using Luderia.Domain.Contexts.Customers.Models;
using Luderia.Infrastructure.Contexts.Customers.Database;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Customers.Repositories;
internal class CustomerRepository : ICustomerRepository
{
    private readonly CustomersDbContext dbContext;

    public CustomerRepository(CustomersDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public Result Create(Customer customer)
    {
        dbContext.Customers.Add(customer);
        return Result.Success();
    }

    public async Task<Customer?> Get(Guid id)
    {
        return await dbContext.Customers
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
