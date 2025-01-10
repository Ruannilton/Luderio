using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Domain.Contexts.Catalog.UseCases;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class GetGameUseCaseTests
{
    private readonly Mock<IGameRepository> _gameRepositoryMock;
    private readonly GetGameUseCase _getGameUseCase;

    public GetGameUseCaseTests()
    {
        _gameRepositoryMock = new Mock<IGameRepository>();
        _getGameUseCase = new GetGameUseCase(_gameRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameNotFound()
    {
        // Arrange
        int gameId = 1;
        _gameRepositoryMock.Setup(x => x.Find(gameId)).ReturnsAsync((Game?)null);

        // Act
        var result = await _getGameUseCase.Execute(gameId);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenGameIsFound()
    {
        // Arrange
        int gameId = 1;
        var game = new Game { BGGId = gameId, Name = "Test Game", Description = "Test Description", MinPlayers = 2, MaxPlayers = 4, MinAge = 8, Duration = 60, Types = new List<GameType>() };
        _gameRepositoryMock.Setup(x => x.Find(gameId)).ReturnsAsync(game);

        // Act
        var result = await _getGameUseCase.Execute(gameId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(gameId, result.Value.BGGId);
    }
}


