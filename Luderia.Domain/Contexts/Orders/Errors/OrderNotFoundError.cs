namespace Luderia.Domain.Contexts.Orders.Errors;
public record OrderNotFoundError() : DomainError(nameof(OrderNotFoundError), "Order not found");
