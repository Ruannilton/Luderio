using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class AddGameUseCaseTests
{
    private readonly Mock<IGameRepository> _gameRepositoryMock;
    private readonly Mock<IGameTypeRepository> _gameTypeRepositoryMock;
    private readonly Mock<IGameIdExistsQuery> _gameIdExistsQueryMock;
    private readonly AddGameUseCase _addGameUseCase;

    public AddGameUseCaseTests()
    {
        _gameRepositoryMock = new Mock<IGameRepository>();
        _gameTypeRepositoryMock = new Mock<IGameTypeRepository>();
        _gameIdExistsQueryMock = new Mock<IGameIdExistsQuery>();
        _addGameUseCase = new AddGameUseCase(_gameRepositoryMock.Object, _gameTypeRepositoryMock.Object, _gameIdExistsQueryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameIdExists()
    {
        // Arrange
        var message = new AddGameMessage { BGGId = 1, Name = "Test Game", Types = new List<string> { "Type1" }, Description = "Description", MinPlayers = 2, MaxPlayers = 4, MinAge = 8, Duration = 60 };
        _gameIdExistsQueryMock.Setup(x => x.Execute(message.BGGId)).ReturnsAsync(true);

        // Act
        var result = await _addGameUseCase.Execute(message);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameIdAlreadExistsError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameTypeNotFound()
    {
        // Arrange
        var message = new AddGameMessage { BGGId = 1, Name = "Test Game", Types = new List<string> { "InvalidType" }, Description = "Description", MinPlayers = 2, MaxPlayers = 4, MinAge = 8, Duration = 60 };
        _gameIdExistsQueryMock.Setup(x => x.Execute(message.BGGId)).ReturnsAsync(false);
        _gameTypeRepositoryMock.Setup(x => x.ListTypes()).ReturnsAsync(new List<GameType> { new GameType { Value = "Type1" } });

        // Act
        var result = await _addGameUseCase.Execute(message);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameTypeNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenGameIsAddedSuccessfully()
    {
        // Arrange
        var message = new AddGameMessage { BGGId = 1, Name = "Test Game", Types = new List<string> { "Type1" }, Description = "Description", MinPlayers = 2, MaxPlayers = 4, MinAge = 8, Duration = 60 };
        _gameIdExistsQueryMock.Setup(x => x.Execute(message.BGGId)).ReturnsAsync(false);
        _gameTypeRepositoryMock.Setup(x => x.ListTypes()).ReturnsAsync(new List<GameType> { new GameType { Value = "Type1" } });

        // Act
        var result = await _addGameUseCase.Execute(message);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(message.BGGId, result.Value.BGGId);
        Assert.Equal(message.Name, result.Value.Name);
        Assert.Equal(message.Description, result.Value.Description);
        Assert.Equal(message.MinPlayers, result.Value.MinPlayers);
        Assert.Equal(message.MaxPlayers, result.Value.MaxPlayers);
        Assert.Equal(message.MinAge, result.Value.MinAge);
        Assert.Equal(message.Duration, result.Value.Duration);
        Assert.Single(result.Value.Types);
        Assert.Equal("Type1", result.Value.Types.First().Value);
    }
}
