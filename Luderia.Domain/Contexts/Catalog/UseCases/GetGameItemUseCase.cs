using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.UseCases;

internal class GetGameItemUseCase : IGetGameItemUseCase
{
    private readonly IGameItemRepository gameItemRepository;
    public GetGameItemUseCase(IGameItemRepository gameItemRepository)
    {
        this.gameItemRepository = gameItemRepository;
    }
    public async Task<Result<GameItem>> Execute(int gameItemId)
    {
        var gameItem = await gameItemRepository.GetGameItem(gameItemId);

        if (gameItem == null)
            return Result.Failure<GameItem>(new GameNotFoundError());

        return Result.Success(gameItem);
    }
}
