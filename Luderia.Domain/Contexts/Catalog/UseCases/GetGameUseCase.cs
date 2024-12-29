using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
using Luderia.Domain.Contexts.Catalog.Models;

namespace Luderia.Domain.Contexts.Catalog.UseCases;
internal class GetGameUseCase(IGameRepository gameRepository) : IGetGameUseCase
{
    public async Task<Result<Game>> Execute(int id)
    {
        var game = await gameRepository.Find(id);

        if (game is null) return Result.Failure(new GameNotFoundError());

        return Result.Success(game);
    }
}
