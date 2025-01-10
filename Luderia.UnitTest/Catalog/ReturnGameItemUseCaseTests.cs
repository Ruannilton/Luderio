using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Domain.Contexts.Catalog.UseCases;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class ReturnGameItemUseCaseTests
{
    private readonly Mock<IGameItemRepository> _gameItemRepositoryMock;
    private readonly UnlockGameItemUseCase _returnGameItemUseCase;

    public ReturnGameItemUseCaseTests()
    {
        _gameItemRepositoryMock = new Mock<IGameItemRepository>();
        _returnGameItemUseCase = new UnlockGameItemUseCase(_gameItemRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameItemNotFound()
    {
        // Arrange
        int gameItemId = 1;
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync((GameItem?)null);

        // Act
        var result = await _returnGameItemUseCase.Execute(gameItemId);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameItemAlreadyAvailable()
    {
        // Arrange
        int gameItemId = 1;
        var gameItem = new GameItem { Id = gameItemId, Available = true };
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync(gameItem);

        // Act
        var result = await _returnGameItemUseCase.Execute(gameItemId);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameItemAlreadyAvailableError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenGameItemIsReturned()
    {
        // Arrange
        int gameItemId = 1;
        var gameItem = new GameItem { Id = gameItemId, Available = false };
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync(gameItem);

        // Act
        var result = await _returnGameItemUseCase.Execute(gameItemId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.True(gameItem.Available);
    }
}



