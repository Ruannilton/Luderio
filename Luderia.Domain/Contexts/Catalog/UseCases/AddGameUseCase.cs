using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
using Luderia.Domain.Contexts.Catalog.Models;

public class AddGameUseCase : IAddGameUseCase
{
    private readonly IGameRepository _gameRepository;
    private readonly IGameTypeRepository _gameTypeRepository;
    private readonly IGameIdExistsQuery _gameIdExistsQuery;
    public AddGameUseCase(IGameRepository gameRepository, IGameTypeRepository gameTypeRepository, IGameIdExistsQuery gameIdExistsQuery)
    {
        _gameRepository = gameRepository;
        _gameTypeRepository = gameTypeRepository;
        _gameIdExistsQuery = gameIdExistsQuery;
    }

    public async Task<Result<Game>> Execute(AddGameMessage message)
    {
        if (await _gameIdExistsQuery.Execute(message.BGGId))
            return Result.Failure<Game>(new GameIdAlreadExistsError());

        var types = await _gameTypeRepository.ListTypes();
        var typesNames = types.Select(x => x.Value).ToList();

        if (message.Types.Any(t => !typesNames.Contains(t)))
            return Result.Failure<Game>(new GameTypeNotFoundError());

        var game = new Game
        {
            BGGId = message.BGGId,
            Name = message.Name,
            Description = message.Description,
            MinPlayers = message.MinPlayers,
            MaxPlayers = message.MaxPlayers,
            MinAge = message.MinAge,
            Duration = message.Duration,
            Types = types.Where(x => message.Types.Contains(x.Value)).ToList()
        };


        _gameRepository.Add(game);

        return Result.Success(game);
    }
}

