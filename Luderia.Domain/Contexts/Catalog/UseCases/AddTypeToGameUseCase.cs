using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;

public class AddTypeToGameUseCase : IAddTypeToGameUseCase
{
    private readonly IGameRepository _gameRepository;
    private readonly IGameTypeRepository _gameTypeRepository;

    public AddTypeToGameUseCase(IGameRepository gameRepository, IGameTypeRepository gameTypeRepository)
    {
        _gameRepository = gameRepository;
        _gameTypeRepository = gameTypeRepository;
    }

    public async Task<Result> Execute(int bggId, string typeName)
    {
        var game = await _gameRepository.Find(bggId);
        if (game == null)
        {
            return Result.Failure(new GameNotFoundError());
        }

        var type = await _gameTypeRepository.FindType(typeName);
        if (type == null)
        {
            return Result.Failure(new GameTypeNotFoundError());
        }

        game.Types.Add(type);
        return Result.Success();
    }
}
