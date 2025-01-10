namespace Luderia.Domain.Contexts.Orders.Models;

public struct CreateOrderMessage
{
    public List<int> GameItemId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime ReturnDate { get; set; }
}