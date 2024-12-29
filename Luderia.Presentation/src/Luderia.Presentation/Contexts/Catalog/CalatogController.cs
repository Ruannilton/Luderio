using Luderia.Domain.Contexts.Catalog.Abstractions;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Presentation.Contexts.Catalog.Requests;
using Luderia.Presentation.Contexts.Catalog.Responses;
using Luderia.Presentation.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Luderia.Presentation.Contexts.Catalog;

[ApiController]
[Route("catalog")]
public class CatalogController : ControllerBase
{
    [HttpGet("games")]
    public async Task<ActionResult<List<GameHeader>>> SearchGames([FromServices] ISearchGameUseCase useCase, [FromQuery] SearchGameRequest request)
    {
        var searchMessage = new SearchGameMessage()
        {
            Duration = request.Duration,
            MaxPlayers = request.MaxPlayers,
            MinAge = request.MinAge,
            MinPlayers = request.MinPlayers,
            Name = request.Name,
            Types = request.Types
        };

        var games = await useCase.Execute(searchMessage);

        return Ok(games);
    }


    [HttpPost("games")]
    public async Task<ActionResult> AddGame([FromServices] IAddGameUseCase useCase, [FromServices] ICatalogUnitOfWork unitOfWork, [FromBody] AddGameRequest request)
    {
        var message = new AddGameMessage
        {
            BGGId = request.BGGId,
            Name = request.Name,
            Description = request.Description,
            MinPlayers = request.MinPlayers,
            MaxPlayers = request.MaxPlayers,
            MinAge = request.MinAge,
            Duration = request.DurationMins,
            Types = request.Types
        };

        var gameResult = await useCase.Execute(message);

        if (gameResult.IsFailure)
        {
            return this.ProblemResponse(gameResult);
        }

        var commitResult = await unitOfWork.Commit();

        if (commitResult.IsFailure)
        {
            return this.ProblemResponse(commitResult);
        }

        return Created();
    }


    [HttpDelete("games/{bggId}")]
    public async Task<ActionResult> RemoveGame([FromServices] IRemoveGameUseCase useCase, [FromServices] ICatalogUnitOfWork unitOfWork, [FromRoute] int bggId)
    {
        var result = await useCase.Execute(bggId);


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


    [HttpPut("games/{bggId}")]
    public async Task<ActionResult> UpdateGame([FromServices] IUpdateGameUseCase useCase, [FromServices] ICatalogUnitOfWork unitOfWork, [FromRoute] int bggId, [FromBody] UpdateGameRequest request)
    {
        var id = bggId;
        var message = new UpdateGameMessage
        {
            Name = request.Name,
            Description = request.Description,
            MinPlayers = request.MinPlayers,
            MaxPlayers = request.MaxPlayers,
            MinAge = request.MinAge,
            Duration = request.Duration
        };

        var result = await useCase.Execute(id, message);

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


    [HttpPost("games/{bggId}/type/{typeName}")]
    public async Task<ActionResult> AddTypeToGame([FromServices] IAddTypeToGameUseCase useCase, [FromServices] ICatalogUnitOfWork unitOfWork, [FromRoute] int bggId, [FromRoute] string typeName)
    {
        var id = bggId;

        var result = await useCase.Execute(id, typeName);

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


    [HttpDelete("games/{bggId}/type/{typeName}")]
    public async Task<ActionResult> RemoveTypeFromGame([FromServices] IRemoveTypeFromGameUseCase useCase, [FromServices] ICatalogUnitOfWork unitOfWork, [FromRoute] int bggId, [FromRoute] string typeName)
    {
        var id = bggId;

        var result = await useCase.Execute(id, typeName);


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


    [HttpPost("types/{typeName}")]
    public async Task<ActionResult> AddGameType([FromServices] IAddGameTypeUseCase useCase, [FromServices] ICatalogUnitOfWork unitOfWork, [FromRoute] string typeName)
    {

        var result = await useCase.Execute(typeName);


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


    [HttpDelete("types/{typeName}")]
    public async Task<ActionResult> RemoveGameType([FromServices] IRemoveGameTypeUseCase useCase, [FromServices] ICatalogUnitOfWork unitOfWork, [FromRoute] string typeName)
    {

        var result = await useCase.Execute(typeName);

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

    [HttpGet("types")]
    public async Task<ActionResult<GameTypeList>> ListTypes([FromServices] IListTypesUseCase useCase)
    {
        var types = await useCase.Execute();
        var response = new GameTypeList(types);
        return Ok(response);
    }
}