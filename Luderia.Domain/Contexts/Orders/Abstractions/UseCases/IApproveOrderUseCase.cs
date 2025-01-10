namespace Luderia.Domain.Contexts.Orders.Abstractions.UseCases;

public interface IApproveOrderUseCase
{
    Task<Result> Execute(int orderId);
}