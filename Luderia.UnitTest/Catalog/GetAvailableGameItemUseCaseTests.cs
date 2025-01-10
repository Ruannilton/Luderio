using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Domain.Contexts.Catalog.UseCases;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class GetAvailableGameItemUseCaseTests
{
    private readonly Mock<IFindAvailableGameItemsQuery> _findAvailableGameItemsQueryMock;
    private readonly GetAvailableGameItemUseCase _getAvailableGameItemUseCase;

    public GetAvailableGameItemUseCaseTests()
    {
        _findAvailableGameItemsQueryMock = new Mock<IFindAvailableGameItemsQuery>();
        _getAvailableGameItemUseCase = new GetAvailableGameItemUseCase(_findAvailableGameItemsQueryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenNoGameItemsAvailable()
    {
        // Arrange
        int gameId = 1;
        _findAvailableGameItemsQueryMock.Setup(x => x.Execute(gameId)).ReturnsAsync(Enumerable.Empty<GameItem>());

        // Act
        var result = await _getAvailableGameItemUseCase.Execute(gameId);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<OutOfStockError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenGameItemIsAvailable()
    {
        // Arrange
        int gameId = 1;
        var gameItems = new List<GameItem>
        {
            new GameItem { Id = 1, GameId = gameId, Available = true, Damages = new List<Damage>() },
            new GameItem { Id = 2, GameId = gameId, Available = true, Damages = new List<Damage> { new Damage(0,"test") } }
        };
        _findAvailableGameItemsQueryMock.Setup(x => x.Execute(gameId)).ReturnsAsync(gameItems);

        // Act
        var result = await _getAvailableGameItemUseCase.Execute(gameId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(1, result.Value.Id);
    }
}

