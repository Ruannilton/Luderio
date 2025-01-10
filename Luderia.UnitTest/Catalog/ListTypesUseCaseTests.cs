using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Domain.Contexts.Catalog.UseCases;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class ListTypesUseCaseTests
{
    private readonly Mock<IListGameTypesQuery> _listGameTypesQueryMock;
    private readonly ListTypesUseCase _listTypesUseCase;

    public ListTypesUseCaseTests()
    {
        _listGameTypesQueryMock = new Mock<IListGameTypesQuery>();
        _listTypesUseCase = new ListTypesUseCase(_listGameTypesQueryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnListOfGameTypes()
    {
        // Arrange
        var gameTypes = new List<GameType>
        {
            new GameType { Id = 1, Value = "Type1" },
            new GameType { Id = 2, Value = "Type2" }
        };
        _listGameTypesQueryMock.Setup(x => x.Execute()).ReturnsAsync(gameTypes);

        // Act
        var result = await _listTypesUseCase.Execute();

        // Assert
        Assert.Equal(gameTypes.Count, result.Count);
        Assert.Equal(gameTypes[0].Id, result[0].Id);
        Assert.Equal(gameTypes[0].Value, result[0].Value);
        Assert.Equal(gameTypes[1].Id, result[1].Id);
        Assert.Equal(gameTypes[1].Value, result[1].Value);
    }

    [Fact]
    public async Task Execute_ShouldReturnEmptyList_WhenNoGameTypesAvailable()
    {
        // Arrange
        var gameTypes = new List<GameType>();
        _listGameTypesQueryMock.Setup(x => x.Execute()).ReturnsAsync(gameTypes);

        // Act
        var result = await _listTypesUseCase.Execute();

        // Assert
        Assert.Empty(result);
    }
}


