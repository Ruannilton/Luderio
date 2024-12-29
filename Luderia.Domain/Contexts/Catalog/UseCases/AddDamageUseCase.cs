using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.UseCases;

internal class AddDamageUseCase : IAddDamageUseCase
{
    private readonly IGameItemRepository gameItemRepository;
    public AddDamageUseCase(IGameItemRepository gameItemRepository)
    {
        this.gameItemRepository = gameItemRepository;
    }
    public async Task<Result> Execute(int gameItemId, string description)
    {
        var gameItem = await gameItemRepository.GetGameItem(gameItemId);

        if (gameItem == null)
            return Result.Failure(new GameNotFoundError());

        gameItem.Damages.Add(new Damage(gameItem.Damages.Count(), description));

        return Result.Success();
    }
}
