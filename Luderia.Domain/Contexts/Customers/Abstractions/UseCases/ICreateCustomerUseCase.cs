using Luderia.Domain.Contexts.Customers.Models;

namespace Luderia.Domain.Contexts.Customers.Abstractions.UseCases;
public interface ICreateCustomerUseCase
{
    Task<Result> Execute(CreateCustomerMessage customer);
}
