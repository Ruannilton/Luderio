using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;

namespace Luderia.Domain.Contexts.Catalog.UseCases;

internal class UpdateDamageUseCase : IUpdateDamageUseCase
{
    private readonly IGameItemRepository gameItemRepository;
    public UpdateDamageUseCase(IGameItemRepository gameItemRepository)
    {
        this.gameItemRepository = gameItemRepository;
    }
    public async Task<Result> Execute(int gameItemId, int damageId, string description)
    {
        var gameItem = await gameItemRepository.GetGameItem(gameItemId);

        if (gameItem == null)
            return Result.Failure(new GameNotFoundError());

        var damageIndex = gameItem.Damages.FindIndex(d => d.Id == damageId);

        if (damageIndex == -1)
            return Result.Failure(new DamageNotFoundError());

        gameItem.Damages[damageIndex] = gameItem.Damages[damageIndex] with { Description = description };

        return Result.Success();
    }
}