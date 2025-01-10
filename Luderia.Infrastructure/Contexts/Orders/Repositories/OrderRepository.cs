using Luderia.Domain.Contexts.Orders.Abstractions.Repositories;
using Luderia.Domain.Contexts.Orders.Models;
using Luderia.Infrastructure.Contexts.Orders.Database;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Orders.Repositories;
internal class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext dbContext;

    public OrderRepository(OrderDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void AddOrder(Order order)
    {
        dbContext.Add(order);
    }

    public async Task<Order?> GetOrder(int id)
    {
        var order = await dbContext.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
        return order;
    }
}
