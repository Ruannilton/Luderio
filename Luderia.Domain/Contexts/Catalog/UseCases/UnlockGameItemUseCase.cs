using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;

namespace Luderia.Domain.Contexts.Catalog.UseCases;

internal class UnlockGameItemUseCase : IUnlockGameItemUseCase
{
    private readonly IGameItemRepository gameItemRepository;
    public UnlockGameItemUseCase(IGameItemRepository gameItemRepository)
    {
        this.gameItemRepository = gameItemRepository;
    }
    public async Task<Result> Execute(int gameItemId)
    {
        var gameItem = await gameItemRepository.GetGameItem(gameItemId);

        if (gameItem == null)
            return Result.Failure(new GameNotFoundError());

        if (gameItem.Available)
            return Result.Failure(new GameItemAlreadyAvailableError());

        gameItem.Available = true;

        return Result.Success();
    }
}
