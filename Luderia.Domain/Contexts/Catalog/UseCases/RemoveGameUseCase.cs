using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;

public class RemoveGameUseCase : IRemoveGameUseCase
{
    private readonly IGameRepository _gameRepository;

    public RemoveGameUseCase(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Result> Execute(int bggId)
    {
        var game = await _gameRepository.Find(bggId);
        if (game == null)
        {
            return Result.Failure(new GameNotFoundError());
        }

        _gameRepository.Remove(game);
        return Result.Success();
    }
}

