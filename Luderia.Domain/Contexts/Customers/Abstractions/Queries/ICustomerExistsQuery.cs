namespace Luderia.Domain.Contexts.Customers.Abstractions.Queries;

public interface ICustomerExistsQuery
{
    Task<bool> Execute(Guid id);
}
