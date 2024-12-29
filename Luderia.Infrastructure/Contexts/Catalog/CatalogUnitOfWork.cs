using Luderia.Domain.Contexts.Catalog.Abstractions;
using Luderia.Domain.Contexts.Customers.Errors;
using Luderia.Infrastructure.Contexts.Catalog.Database;

namespace Luderia.Infrastructure.Contexts.Catalog;
internal class CatalogUnitOfWork : ICatalogUnitOfWork
{
    private readonly CatalogDbContext dbContext;

    public CatalogUnitOfWork(CatalogDbContext dbContext)
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
