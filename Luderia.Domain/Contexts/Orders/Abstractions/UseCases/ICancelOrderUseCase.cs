namespace Luderia.Domain.Contexts.Orders.Abstractions.UseCases;

public interface ICancelOrderUseCase
{
    Task<Result> Execute(int orderId);
}
