namespace Luderia.Domain.Contexts.Customers.Abstractions.UseCases;

public interface IActivateCustomerUseCase
{
    Task<Result> Execute(Guid id);
}
