namespace Luderia.Domain.Contexts.Orders.Abstractions;

public interface IOrderUnitOfWork
{
    public void BeginTransaction();
    public Task<Result> Commit();
    public Task Rollback();
}