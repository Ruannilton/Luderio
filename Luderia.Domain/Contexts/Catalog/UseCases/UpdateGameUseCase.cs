using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Abstractions.UseCases;
using Luderia.Domain.Contexts.Catalog.Models;

public class UpdateGameUseCase : IUpdateGameUseCase
{
    private readonly IGameRepository _gameRepository;

    public UpdateGameUseCase(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Result<Game>> Execute(int bggId, UpdateGameMessage request)
    {
        var game = await _gameRepository.Find(bggId);
        if (game == null)
        {
            return Result.Failure(new GameNotFoundError());
        }

        game.Name = request.Name ?? game.Name;
        game.Description = request.Description ?? game.Description;
        game.MinPlayers = request.MinPlayers ?? game.MinPlayers;
        game.MaxPlayers = request.MaxPlayers ?? game.MaxPlayers;
        game.MinAge = request.MinAge ?? game.MinAge;
        game.Duration = request.Duration ?? game.Duration;

        return Result.Success(game);
    }
}

