namespace Luderia.Domain.Contexts.Customers.Abstractions;
public interface ICustomersUnitOfWork
{
    public void BeginTransaction();
    public Task<Result> Commit();
    public Task Rollback();
}
