using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Domain.Contexts.Catalog.UseCases;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class GetGameItemUseCaseTests
{
    private readonly Mock<IGameItemRepository> _gameItemRepositoryMock;
    private readonly GetGameItemUseCase _getGameItemUseCase;

    public GetGameItemUseCaseTests()
    {
        _gameItemRepositoryMock = new Mock<IGameItemRepository>();
        _getGameItemUseCase = new GetGameItemUseCase(_gameItemRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameItemNotFound()
    {
        // Arrange
        int gameItemId = 1;
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync((GameItem?)null);

        // Act
        var result = await _getGameItemUseCase.Execute(gameItemId);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenGameItemIsFound()
    {
        // Arrange
        int gameItemId = 1;
        var gameItem = new GameItem { Id = gameItemId, GameId = 1, Available = true };
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync(gameItem);

        // Act
        var result = await _getGameItemUseCase.Execute(gameItemId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(gameItemId, result.Value.Id);
    }
}

