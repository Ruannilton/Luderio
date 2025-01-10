using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Domain.Contexts.Catalog.UseCases;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class BorrowGameItemUseCaseTests
{
    private readonly Mock<IGameItemRepository> _gameItemRepositoryMock;
    private readonly LockGameItemUseCase _borrowGameItemUseCase;

    public BorrowGameItemUseCaseTests()
    {
        _gameItemRepositoryMock = new Mock<IGameItemRepository>();
        _borrowGameItemUseCase = new LockGameItemUseCase(_gameItemRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameItemNotFound()
    {
        // Arrange
        int gameItemId = 1;
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync((GameItem?)null);

        // Act
        var result = await _borrowGameItemUseCase.Execute(gameItemId);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameItemNotAvailable()
    {
        // Arrange
        int gameItemId = 1;
        var gameItem = new GameItem { Id = gameItemId, Available = false };
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync(gameItem);

        // Act
        var result = await _borrowGameItemUseCase.Execute(gameItemId);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameItemNotAvailableError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenGameItemIsBorrowed()
    {
        // Arrange
        int gameItemId = 1;
        var gameItem = new GameItem { Id = gameItemId, Available = true };
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync(gameItem);

        // Act
        var result = await _borrowGameItemUseCase.Execute(gameItemId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(gameItem.Available);
    }
}
