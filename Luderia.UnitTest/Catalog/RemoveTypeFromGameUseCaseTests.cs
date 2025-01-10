using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class RemoveTypeFromGameUseCaseTests
{
    private readonly Mock<IGameRepository> _gameRepositoryMock;
    private readonly RemoveTypeFromGameUseCase _removeTypeFromGameUseCase;

    public RemoveTypeFromGameUseCaseTests()
    {
        _gameRepositoryMock = new Mock<IGameRepository>();
        _removeTypeFromGameUseCase = new RemoveTypeFromGameUseCase(_gameRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameNotFound()
    {
        // Arrange
        int bggId = 1;
        string typeName = "Type1";
        _gameRepositoryMock.Setup(x => x.Find(bggId)).ReturnsAsync((Game?)null);

        // Act
        var result = await _removeTypeFromGameUseCase.Execute(bggId, typeName);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameTypeNotFound()
    {
        // Arrange
        int bggId = 1;
        string typeName = "Type1";
        var game = new Game { BGGId = bggId, Types = new List<GameType>() };
        _gameRepositoryMock.Setup(x => x.Find(bggId)).ReturnsAsync(game);

        // Act
        var result = await _removeTypeFromGameUseCase.Execute(bggId, typeName);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameTypeNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenGameTypeIsRemoved()
    {
        // Arrange
        int bggId = 1;
        string typeName = "Type1";
        var gameType = new GameType { Value = typeName };
        var game = new Game { BGGId = bggId, Types = new List<GameType> { gameType } };
        _gameRepositoryMock.Setup(x => x.Find(bggId)).ReturnsAsync(game);

        // Act
        var result = await _removeTypeFromGameUseCase.Execute(bggId, typeName);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.DoesNotContain(gameType, game.Types);
    }
}



