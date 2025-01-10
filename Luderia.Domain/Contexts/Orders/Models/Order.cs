namespace Luderia.Domain.Contexts.Orders.Models;

public class Order
{
    public int Id { get; set; }
    public List<int> GameItemId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime ReturnDate { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
