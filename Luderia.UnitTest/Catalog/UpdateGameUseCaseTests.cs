using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class UpdateGameUseCaseTests
{
    private readonly Mock<IGameRepository> _gameRepositoryMock;
    private readonly UpdateGameUseCase _updateGameUseCase;

    public UpdateGameUseCaseTests()
    {
        _gameRepositoryMock = new Mock<IGameRepository>();
        _updateGameUseCase = new UpdateGameUseCase(_gameRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameNotFound()
    {
        // Arrange
        int bggId = 1;
        var request = new UpdateGameMessage { Name = "Updated Game" };
        _gameRepositoryMock.Setup(x => x.Find(bggId)).ReturnsAsync((Game?)null);

        // Act
        var result = await _updateGameUseCase.Execute(bggId, request);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenGameIsUpdated()
    {
        // Arrange
        int bggId = 1;
        var game = new Game { BGGId = bggId, Name = "Old Game", Description = "Old Description", MinPlayers = 2, MaxPlayers = 4, MinAge = 8, Duration = 60 };
        var request = new UpdateGameMessage { Name = "Updated Game", Description = "Updated Description", MinPlayers = 3, MaxPlayers = 5, MinAge = 10, Duration = 90 };
        _gameRepositoryMock.Setup(x => x.Find(bggId)).ReturnsAsync(game);

        // Act
        var result = await _updateGameUseCase.Execute(bggId, request);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(request.Name, result.Value.Name);
        Assert.Equal(request.Description, result.Value.Description);
        Assert.Equal(request.MinPlayers, result.Value.MinPlayers);
        Assert.Equal(request.MaxPlayers, result.Value.MaxPlayers);
        Assert.Equal(request.MinAge, result.Value.MinAge);
        Assert.Equal(request.Duration, result.Value.Duration);
    }

    [Fact]
    public async Task Execute_ShouldNotUpdateFields_WhenRequestFieldsAreNull()
    {
        // Arrange
        int bggId = 1;
        var game = new Game { BGGId = bggId, Name = "Old Game", Description = "Old Description", MinPlayers = 2, MaxPlayers = 4, MinAge = 8, Duration = 60 };
        var request = new UpdateGameMessage { Name = null, Description = null, MinPlayers = null, MaxPlayers = null, MinAge = null, Duration = null };
        _gameRepositoryMock.Setup(x => x.Find(bggId)).ReturnsAsync(game);

        // Act
        var result = await _updateGameUseCase.Execute(bggId, request);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Old Game", result.Value.Name);
        Assert.Equal("Old Description", result.Value.Description);
        Assert.Equal(2, result.Value.MinPlayers);
        Assert.Equal(4, result.Value.MaxPlayers);
        Assert.Equal(8, result.Value.MinAge);
        Assert.Equal(60, result.Value.Duration);
    }
}




