using Luderia.Domain.Contexts.Customers.Errors;
using Luderia.Domain.Contexts.Orders.Abstractions;
using Luderia.Infrastructure.Contexts.Orders.Database;

namespace Luderia.Infrastructure.Contexts.Orders;
internal class OrderUnitOfWork : IOrderUnitOfWork
{
    private readonly OrderDbContext dbContext;

    public OrderUnitOfWork(OrderDbContext dbContext)
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

    public async Task Rollback()
    {
        await Task.CompletedTask;
    }
}
