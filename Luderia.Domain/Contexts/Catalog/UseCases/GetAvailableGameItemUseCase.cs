using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.UseCases;

internal class GetAvailableGameItemUseCase : IGetAvailableGameItemUseCase
{
    private readonly IFindAvailableGameItemsQuery query;

    public GetAvailableGameItemUseCase(IFindAvailableGameItemsQuery gameItemRepository)
    {
        this.query = gameItemRepository;
    }
    public async Task<Result<GameItem>> Execute(int gameId)
    {
        var gameItems = await query.Execute(gameId);

        if (gameItems.Count() == 0)
            return Result.Failure<GameItem>(new OutOfStockError());

        var gameItem = gameItems.OrderBy(g => g.Damages.Count()).First();

        return Result.Success(gameItem);
    }
}
