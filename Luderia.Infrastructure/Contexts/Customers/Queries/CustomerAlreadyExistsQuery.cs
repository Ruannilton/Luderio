using Luderia.Domain.Contexts.Customers.Abstractions.Queries;
using Luderia.Domain.Contexts.Customers.Models;
using Luderia.Infrastructure.Contexts.Customers.Database;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Customers.Queries;
internal class CustomerAlreadyExistsQuery : ICustomerAlreadyExistsQuery
{
    private readonly CustomersDbContext dbContext;

    public CustomerAlreadyExistsQuery(CustomersDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<Customer?> Execute(string email, string cpf, string phone)
    {
        var customer = await dbContext.Customers
            .Where(c => c.Email == email || c.Cpf == cpf || c.Phone == phone)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return customer;
    }
}
