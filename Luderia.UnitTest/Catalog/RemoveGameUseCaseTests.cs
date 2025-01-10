using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class RemoveGameUseCaseTests
{
    private readonly Mock<IGameRepository> _gameRepositoryMock;
    private readonly RemoveGameUseCase _removeGameUseCase;

    public RemoveGameUseCaseTests()
    {
        _gameRepositoryMock = new Mock<IGameRepository>();
        _removeGameUseCase = new RemoveGameUseCase(_gameRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameNotFound()
    {
        // Arrange
        int bggId = 1;
        _gameRepositoryMock.Setup(x => x.Find(bggId)).ReturnsAsync((Game?)null);

        // Act
        var result = await _removeGameUseCase.Execute(bggId);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenGameIsRemoved()
    {
        // Arrange
        int bggId = 1;
        var game = new Game { BGGId = bggId, Name = "Test Game" };
        _gameRepositoryMock.Setup(x => x.Find(bggId)).ReturnsAsync(game);

        // Act
        var result = await _removeGameUseCase.Execute(bggId);

        // Assert
        Assert.True(result.IsSuccess);
        _gameRepositoryMock.Verify(x => x.Remove(game), Times.Once);
    }
}



