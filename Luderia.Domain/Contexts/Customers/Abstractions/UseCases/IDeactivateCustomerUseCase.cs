namespace Luderia.Domain.Contexts.Customers.Abstractions.UseCases;

public interface IDeactivateCustomerUseCase
{
    Task<Result> Execute(Guid id);
}
