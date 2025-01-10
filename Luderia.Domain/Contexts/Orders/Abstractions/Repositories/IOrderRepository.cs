using Luderia.Domain.Contexts.Orders.Models;

namespace Luderia.Domain.Contexts.Orders.Abstractions.Repositories;
public interface IOrderRepository
{
    void AddOrder(Order order);
    Task<Order?> GetOrder(int id);
}
