using Luderia.Domain.Contexts.Orders.Abstractions.Repositories;
using Luderia.Domain.Contexts.Orders.Abstractions.UseCases;
using Luderia.Domain.Contexts.Orders.Models;

namespace Luderia.Domain.Contexts.Orders.UseCases;
internal class CreateOrderUseCase : ICreateOrderUseCase
{
    private readonly IOrderRepository orderRepository;

    public CreateOrderUseCase(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public async Task<Result> Execute(CreateOrderMessage message)
    {
        var order = new Order()
        {
            CustomerId = message.CustomerId,
            GameItemId = message.GameItemId,
            ReturnDate = message.ReturnDate,
            Status = OrderStatus.Pending,
        };

        orderRepository.AddOrder(order);

        return Result.Success();
    }
}
