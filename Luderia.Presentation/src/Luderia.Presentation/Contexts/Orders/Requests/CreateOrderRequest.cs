namespace Luderia.Presentation.Contexts.Orders.Requests;

public class CreateOrderRequest
{
    public List<int> GameItemId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime ReturnDate { get; set; }
}
