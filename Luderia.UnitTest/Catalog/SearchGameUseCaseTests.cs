using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Domain.Contexts.Catalog.UseCases;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class SearchGameUseCaseTests
{
    private readonly Mock<ISearchGameQuery> _searchGameQueryMock;
    private readonly SearchGameUseCase _searchGameUseCase;

    public SearchGameUseCaseTests()
    {
        _searchGameQueryMock = new Mock<ISearchGameQuery>();
        _searchGameUseCase = new SearchGameUseCase(_searchGameQueryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnListOfGameHeaders()
    {
        // Arrange
        var criteria = new SearchGameMessage { Name = "Test" };
        var gameHeaders = new List<GameHeader>
        {
            new GameHeader { BGGId = 1, Name = "Test Game 1" },
            new GameHeader { BGGId = 2, Name = "Test Game 2" }
        };
        _searchGameQueryMock.Setup(x => x.Execute(criteria)).ReturnsAsync(gameHeaders);

        // Act
        var result = await _searchGameUseCase.Execute(criteria);

        // Assert
        Assert.Equal(gameHeaders.Count, result.Count);
        Assert.Equal(gameHeaders[0].BGGId, result[0].BGGId);
        Assert.Equal(gameHeaders[0].Name, result[0].Name);
        Assert.Equal(gameHeaders[1].BGGId, result[1].BGGId);
        Assert.Equal(gameHeaders[1].Name, result[1].Name);
    }

    [Fact]
    public async Task Execute_ShouldReturnEmptyList_WhenNoGamesFound()
    {
        // Arrange
        var criteria = new SearchGameMessage { Name = "NonExistentGame" };
        var gameHeaders = new List<GameHeader>();
        _searchGameQueryMock.Setup(x => x.Execute(criteria)).ReturnsAsync(gameHeaders);

        // Act
        var result = await _searchGameUseCase.Execute(criteria);

        // Assert
        Assert.Empty(result);
    }
}



