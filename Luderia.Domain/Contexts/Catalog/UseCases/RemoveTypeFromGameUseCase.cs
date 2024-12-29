using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;

public class RemoveTypeFromGameUseCase : IRemoveTypeFromGameUseCase
{
    private readonly IGameRepository _gameRepository;

    public RemoveTypeFromGameUseCase(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Result> Execute(int bggId, string name)
    {
        var game = await _gameRepository.Find(bggId);
        if (game == null)
        {
            return Result.Failure(new GameNotFoundError());
        }

        var type = game.Types.FirstOrDefault(x => x.Value == name);

        if (type == null)
        {
            return Result.Failure(new GameTypeNotFoundError());
        }

        game.Types.Remove(type);

        return Result.Success();
    }
}
