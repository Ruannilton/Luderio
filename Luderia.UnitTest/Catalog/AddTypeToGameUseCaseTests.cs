using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class AddTypeToGameUseCaseTests
{
    private readonly Mock<IGameRepository> _gameRepositoryMock;
    private readonly Mock<IGameTypeRepository> _gameTypeRepositoryMock;
    private readonly AddTypeToGameUseCase _addTypeToGameUseCase;

    public AddTypeToGameUseCaseTests()
    {
        _gameRepositoryMock = new Mock<IGameRepository>();
        _gameTypeRepositoryMock = new Mock<IGameTypeRepository>();
        _addTypeToGameUseCase = new AddTypeToGameUseCase(_gameRepositoryMock.Object, _gameTypeRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameNotFound()
    {
        // Arrange
        int bggId = 1;
        string typeName = "Type1";
        _gameRepositoryMock.Setup(x => x.Find(bggId)).ReturnsAsync((Game?)null);

        // Act
        var result = await _addTypeToGameUseCase.Execute(bggId, typeName);

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
        _gameTypeRepositoryMock.Setup(x => x.FindType(typeName)).ReturnsAsync((GameType?)null);

        // Act
        var result = await _addTypeToGameUseCase.Execute(bggId, typeName);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameTypeNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenTypeIsAddedToGame()
    {
        // Arrange
        int bggId = 1;
        string typeName = "Type1";
        var game = new Game { BGGId = bggId, Types = new List<GameType>() };
        var gameType = new GameType { Value = typeName };
        _gameRepositoryMock.Setup(x => x.Find(bggId)).ReturnsAsync(game);
        _gameTypeRepositoryMock.Setup(x => x.FindType(typeName)).ReturnsAsync(gameType);

        // Act
        var result = await _addTypeToGameUseCase.Execute(bggId, typeName);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Contains(gameType, game.Types);
    }
}
