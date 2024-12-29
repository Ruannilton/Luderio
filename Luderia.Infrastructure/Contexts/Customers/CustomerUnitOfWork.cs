using Luderia.Domain.Contexts.Customers.Abstractions;
using Luderia.Domain.Contexts.Customers.Errors;
using Luderia.Infrastructure.Contexts.Customers.Database;

namespace Luderia.Infrastructure.Contexts.Customers;
internal class CustomerUnitOfWork : ICustomersUnitOfWork
{
    private readonly CustomersDbContext dbContext;

    public CustomerUnitOfWork(CustomersDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void BeginTransaction()
    {
    }

    public async Task<Result> Commit()
    {
        try
        {
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {

            return Result.Failure(new FailToCommitChangesError());
        }

        return Result.Success();
    }

    public Task Rollback()
    {
        return Task.CompletedTask;
    }
}
