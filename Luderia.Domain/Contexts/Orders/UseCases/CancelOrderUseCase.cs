using Luderia.Domain.Contexts.Orders.Abstractions.Repositories;
using Luderia.Domain.Contexts.Orders.Abstractions.UseCases;
using Luderia.Domain.Contexts.Orders.Errors;
using Luderia.Domain.Contexts.Orders.Models;

namespace Luderia.Domain.Contexts.Orders.UseCases;

internal class CancelOrderUseCase : ICancelOrderUseCase
{
    private readonly IOrderRepository orderRepository;

    public CancelOrderUseCase(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }
    public async Task<Result> Execute(int orderId)
    {
        var order = await orderRepository.GetOrder(orderId);

        if (order == null)
        {
            return Result.Failure(new OrderNotFoundError());
        }

        order.Status = OrderStatus.Canceled;

        return Result.Success();
    }
}
