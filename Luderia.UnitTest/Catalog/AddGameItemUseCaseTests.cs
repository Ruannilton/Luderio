using Luderia.Domain.Contexts.Catalog.Abstractions.Queries;
using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Domain.Contexts.Catalog.UseCases;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class AddGameItemUseCaseTests
{
    private readonly Mock<IGameIdExistsQuery> mockGameIdExistsQuery;
    private readonly Mock<IGameItemRepository> mockGameItemRepository;
    private readonly AddGameItemUseCase addGameItemUseCase;

    public AddGameItemUseCaseTests()
    {
        mockGameIdExistsQuery = new Mock<IGameIdExistsQuery>();
        mockGameItemRepository = new Mock<IGameItemRepository>();
        addGameItemUseCase = new AddGameItemUseCase(mockGameIdExistsQuery.Object, mockGameItemRepository.Object);
    }

    [Fact]
    public async Task Execute_GameIdDoesNotExist_ReturnsFailure()
    {
        // Arrange
        int gameId = 1;
        mockGameIdExistsQuery.Setup(x => x.Execute(gameId)).ReturnsAsync(false);

        // Act
        var result = await addGameItemUseCase.Execute(gameId);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_GameIdExists_AddsGameItemAndReturnsSuccess()
    {
        // Arrange
        int gameId = 1;
        mockGameIdExistsQuery.Setup(x => x.Execute(gameId)).ReturnsAsync(true);

        // Act
        var result = await addGameItemUseCase.Execute(gameId);

        // Assert
        Assert.True(result.IsSuccess);
        mockGameItemRepository.Verify(x => x.AddGameItem(It.Is<GameItem>(g => g.GameId == gameId && g.Available == true)), Times.Once);
    }
}
