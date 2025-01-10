using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class RemoveGameTypeUseCaseTests
{
    private readonly Mock<IGameTypeRepository> _gameTypeRepositoryMock;
    private readonly RemoveGameTypeUseCase _removeGameTypeUseCase;

    public RemoveGameTypeUseCaseTests()
    {
        _gameTypeRepositoryMock = new Mock<IGameTypeRepository>();
        _removeGameTypeUseCase = new RemoveGameTypeUseCase(_gameTypeRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenGameTypeIsRemoved()
    {
        // Arrange
        string typeName = "Type1";
        _gameTypeRepositoryMock.Setup(x => x.RemoveType(typeName));

        // Act
        var result = await _removeGameTypeUseCase.Execute(typeName);

        // Assert
        Assert.True(result.IsSuccess);
        _gameTypeRepositoryMock.Verify(x => x.RemoveType(typeName), Times.Once);
    }
}


