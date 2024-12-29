using Luderia.Domain.Contexts.Customers.Models;

namespace Luderia.Domain.Contexts.Customers.Abstractions.Queries;
public interface ICustomerAlreadyExistsQuery
{
    Task<Customer?> Execute(string email, string cpf, string phone);
}
