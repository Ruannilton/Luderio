using Luderia.Domain.Contexts.Orders.Abstractions;
using Luderia.Domain.Contexts.Orders.Abstractions.UseCases;
using Luderia.Domain.Contexts.Orders.Models;
using Luderia.Presentation.Contexts.Orders.Requests;
using Luderia.Presentation.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Luderia.Presentation.Contexts.Orders;

[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateOrder([FromServices] ICreateOrderUseCase useCase, [FromServices] IOrderUnitOfWork unitOfWork, [FromBody] CreateOrderRequest request)
    {
        var message = new CreateOrderMessage()
        {
            CustomerId = request.CustomerId,
            GameItemId = request.GameItemId,
            ReturnDate = request.ReturnDate,
        };

        var result = await useCase.Execute(message);

        if (result.IsFailure)
        {
            return this.ProblemResponse(result);
        }

        var commitResult = await unitOfWork.Commit();

        if (commitResult.IsFailure)
        {
            return this.ProblemResponse(commitResult);
        }

        return Created();
    }

    [HttpPatch("/{orderId}/status")]
    public async Task<ActionResult> UpdateOrderStatus([FromServices] IApproveOrderUseCase approvedCase, [FromServices] ICancelOrderUseCase cancelCase, [FromServices] IOrderUnitOfWork unitOfWork, [FromRoute] int orderId, [FromBody] UpdateOrderStatusRequest request)
    {
        var status = Enum.Parse<OrderStatus>(request.Status);

        var result = status switch
        {
            OrderStatus.Approved => await approvedCase.Execute(orderId),
            OrderStatus.Canceled => await cancelCase.Execute(orderId),
            _ => Result.Failure(new InvalidOptionError())
        };


        if (result.IsFailure)
        {
            return this.ProblemResponse(result);
        }

        var commitResult = await unitOfWork.Commit();

        if (commitResult.IsFailure)
        {
            return this.ProblemResponse(commitResult);
        }

        return NoContent();
    }

}
