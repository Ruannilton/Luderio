using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;

namespace Luderia.Domain.Contexts.Catalog.UseCases;

internal class LockGameItemUseCase : ILockGameItemUseCase
{
    private readonly IGameItemRepository gameItemRepository;
    public LockGameItemUseCase(IGameItemRepository gameItemRepository)
    {
        this.gameItemRepository = gameItemRepository;
    }
    public async Task<Result> Execute(int gameItemId)
    {
        var gameItem = await gameItemRepository.GetGameItem(gameItemId);

        if (gameItem == null)
            return Result.Failure(new GameNotFoundError());

        if (!gameItem.Available)
            return Result.Failure(new GameItemNotAvailableError());

        gameItem.Available = false;

        return Result.Success();
    }
}
