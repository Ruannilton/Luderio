using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.UseCases;
internal class AddGameItemUseCase : IAddGameItemUseCase
{
    private readonly IGameIdExistsQuery gameIdExistsQuery;
    private readonly IGameItemRepository gameItemRepository;

    public AddGameItemUseCase(IGameIdExistsQuery gameIdExistsQuery, IGameItemRepository gameItemRepository)
    {
        this.gameIdExistsQuery = gameIdExistsQuery;
        this.gameItemRepository = gameItemRepository;
    }
    public async Task<Result> Execute(int gameId)
    {
        if (!await gameIdExistsQuery.Execute(gameId))
            return Result.Failure(new GameNotFoundError());

        var gameItem = new GameItem()
        {
            GameId = gameId,
            Available = true,
            Damages = new List<Damage>(),
        };

        gameItemRepository.AddGameItem(gameItem);

        return Result.Success();
    }
}