using Luderia.Domain.Contexts.Customers.Models;

namespace Luderia.Domain.Contexts.Customers.Abstractions.UseCases;

public interface IUpdateCustomerUseCase
{
    Task<Result> Execute(Guid customerId, CostumerUpateMessage message);
}
