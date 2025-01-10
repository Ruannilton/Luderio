using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class AddGameTypeUseCaseTests
{
    private readonly Mock<IGameTypeRepository> _gameTypeRepositoryMock;
    private readonly Mock<IGameTypeExistsQuery> _gameTypeExistsQueryMock;
    private readonly AddGameTypeUseCase _addGameTypeUseCase;

    public AddGameTypeUseCaseTests()
    {
        _gameTypeRepositoryMock = new Mock<IGameTypeRepository>();
        _gameTypeExistsQueryMock = new Mock<IGameTypeExistsQuery>();
        _addGameTypeUseCase = new AddGameTypeUseCase(_gameTypeRepositoryMock.Object, _gameTypeExistsQueryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameTypeExists()
    {
        // Arrange
        var type = "ExistingType";
        _gameTypeExistsQueryMock.Setup(x => x.Execute(type)).ReturnsAsync(true);

        // Act
        var result = await _addGameTypeUseCase.Execute(type);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameTypeAlreadyExistsError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenGameTypeDoesNotExist()
    {
        // Arrange
        var type = "NewType";
        _gameTypeExistsQueryMock.Setup(x => x.Execute(type)).ReturnsAsync(false);

        // Act
        var result = await _addGameTypeUseCase.Execute(type);

        // Assert
        Assert.True(result.IsSuccess);
        _gameTypeRepositoryMock.Verify(x => x.AddType(type), Times.Once);
    }
}
