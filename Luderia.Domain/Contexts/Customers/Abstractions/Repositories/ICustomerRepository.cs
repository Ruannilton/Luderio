using Luderia.Domain.Contexts.Customers.Models;
namespace Luderia.Domain.Contexts.Customers.Abstractions.Repositories;
public interface ICustomerRepository
{
    Result Create(Customer customer);
    Task<Customer?> Get(Guid id);

}
