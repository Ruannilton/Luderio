using Luderia.Domain.Contexts.Customers.Models;

namespace Luderia.Domain.Contexts.Customers.Abstractions.Queries;

public interface IGetCustomerQuery
{
    Task<Customer?> Execute(Guid id);
}