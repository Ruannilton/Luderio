using Luderia.Domain.Contexts.Customers.Models;

namespace Luderia.Domain.Contexts.Customers.Abstractions.UseCases;

public interface IGetCustomerUseCase
{
    Task<Result<Customer>> Execute(Guid id);
}
