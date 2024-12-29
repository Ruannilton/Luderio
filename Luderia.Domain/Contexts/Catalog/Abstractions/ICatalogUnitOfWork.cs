namespace Luderia.Domain.Contexts.Catalog.Abstractions;

public interface ICatalogUnitOfWork
{
    public void BeginTransaction();
    public Task<Result> Commit();
    public Task Rollback();
}
