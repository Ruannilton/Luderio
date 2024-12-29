using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;

namespace Luderia.Domain.Contexts.Catalog.UseCases;

internal class RemoveDamageUseCase : IRemoveDamageUseCase
{
    private readonly IGameItemRepository gameItemRepository;
    public RemoveDamageUseCase(IGameItemRepository gameItemRepository)
    {
        this.gameItemRepository = gameItemRepository;
    }
    public async Task<Result> Execute(int gameItemId, int damageId)
    {
        var gameItem = await gameItemRepository.GetGameItem(gameItemId);

        if (gameItem == null)
            return Result.Failure(new GameNotFoundError());

        var damage = gameItem.Damages.FirstOrDefault(d => d.Id == damageId);

        if (damage == null)
            return Result.Failure(new DamageNotFoundError());

        gameItem.Damages.Remove(damage);
        return Result.Success();
    }
}
