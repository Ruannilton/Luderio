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

        var damage = gameItem.Damages.FirstOrDefault(d => d.Id == damageId);

        if (damage == null)
            return Result.Failure(new DamageNotFoundError());

        damage = damage with { Description = description };
        return Result.Success();
    }
}