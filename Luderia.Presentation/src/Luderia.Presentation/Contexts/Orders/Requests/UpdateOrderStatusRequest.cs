using Luderia.Domain.Contexts.Orders.Models;
using System.ComponentModel.DataAnnotations;

namespace Luderia.Presentation.Contexts.Orders.Requests;

public class UpdateOrderStatusRequest
{
    [AllowedValues(values: [nameof(OrderStatus.Approved), nameof(OrderStatus.Canceled)])]
    public string Status { get; set; }
}
