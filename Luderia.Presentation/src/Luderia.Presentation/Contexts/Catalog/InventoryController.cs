using Luderia.Domain.Contexts.Catalog.Abstractions;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Presentation.Contexts.Catalog.Requests;
using Luderia.Presentation.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Luderia.Presentation.Contexts.Catalog;

[ApiController]
[Route("catalog")]
public class InventoryController : ControllerBase
{
    [HttpPost("inventory")]
    public async Task<ActionResult> AddGameItem([FromServices] IAddGameItemUseCase useCase, [FromServices] ICatalogUnitOfWork unitOfWork, [FromBody] AddGameItemRequest request)
    {
        var result = await useCase.Execute(request.BggId);

        if (result.IsFailure)
        {
            return this.ProblemResponse(result);
        }

        var commitResult = await unitOfWork.Commit();

        if(commitResult.IsFailure)
        {
            return this.ProblemResponse(commitResult);
        }

        return Created();
    }

    [HttpGet("inventory/{gameId}/available")]
    public async Task<ActionResult<GameItem>> GetAvailableItem([FromServices] IGetAvailableGameItemUseCase useCase, [FromRoute] int gameId)
    {
        var itemResult = await useCase.Execute(gameId);

        if (itemResult.IsFailure)
        {
            return this.ProblemResponse(itemResult);
        }

        var item = itemResult.Value;
        
        return Ok(item);
    }

    [HttpGet("inventory/item/{itemId}")]
    public async Task<ActionResult<GameItem>> GetItem([FromServices] IGetGameItemUseCase useCase, [FromRoute] int itemId)
    {
        var itemResult = await useCase.Execute(itemId);

        if (itemResult.IsFailure)
        {
            return this.ProblemResponse(itemResult);
        }

        var item = itemResult.Value;

        return Ok(item);
    }

    [HttpPut("inventory/item/{itemId}/rent")]
    public async Task<ActionResult> RentItem([FromServices] IRentGameItemUseCase useCase, [FromServices] ICatalogUnitOfWork unitOfWork, [FromRoute] int itemId)
    {
        var itemResult = await useCase.Execute(itemId);

        if (itemResult.IsFailure)
        {
            return this.ProblemResponse(itemResult);
        }

        return NoContent();
    }

    [HttpPut("inventory/item/{itemId}/return")]
    public async Task<ActionResult> ReturnItem([FromServices] IReturnGameItemUseCase useCase, [FromServices] ICatalogUnitOfWork unitOfWork, [FromRoute] int itemId)
    {
        var result = await useCase.Execute(itemId);

        if (result.IsFailure)
        {
            return this.ProblemResponse(result);
        }

        return NoContent();
    }

    [HttpPost("inventory/item/{itemId}/damage")]
    public async Task<ActionResult> RegisterDamage([FromServices] IAddDamageUseCase useCase, [FromServices] ICatalogUnitOfWork unitOfWork, [FromRoute] int itemId, [FromBody] AddDamageRequest request)
    {
        var result = await useCase.Execute(itemId, request.Descripcion);

        if (result.IsFailure)
        {
            return this.ProblemResponse(result);
        }

        var commitResult = await unitOfWork.Commit();

        if(commitResult.IsFailure)
        {
            return this.ProblemResponse(commitResult);
        }

        return NoContent();
    }

    [HttpPut("inventory/item/{itemId}/damage/{damageId}")]
    public async Task<ActionResult> UpdateDamage([FromServices] IUpdateDamageUseCase useCase, [FromServices] ICatalogUnitOfWork unitOfWork, [FromRoute] int itemId, [FromRoute] int damageId, [FromBody] UpdateDamageRequest request)
    {
        var result = await useCase.Execute(itemId, damageId, request.Descripcion);

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

    [HttpDelete("inventory/item/{itemId}/damage/{damageId}")]
    public async Task<ActionResult> RemoveDamage([FromServices] IRemoveDamageUseCase useCase, [FromServices] ICatalogUnitOfWork unitOfWork, [FromRoute] int itemId, [FromRoute] int damageId)
    {
        var result = await useCase.Execute(itemId, damageId);

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