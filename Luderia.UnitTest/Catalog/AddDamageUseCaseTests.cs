using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Domain.Contexts.Catalog.UseCases;
using Moq;

namespace Luderia.UnitTest.Catalog;

public class AddDamageUseCaseTests
{
    private readonly Mock<IGameItemRepository> mockGameItemRepository;
    private readonly AddDamageUseCase addDamageUseCase;

    public AddDamageUseCaseTests()
    {
        mockGameItemRepository = new Mock<IGameItemRepository>();
        addDamageUseCase = new AddDamageUseCase(mockGameItemRepository.Object);
    }

    [Fact]
    public async Task Execute_GameItemNotFound_ReturnsFailure()
    {
        // Arrange
        int gameItemId = 1;
        string description = "Test damage";
        mockGameItemRepository.Setup(repo => repo.GetGameItem(gameItemId)).ReturnsAsync((GameItem?)null);

        // Act
        var result = await addDamageUseCase.Execute(gameItemId, description);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_GameItemFound_AddsDamageAndReturnsSuccess()
    {
        // Arrange
        int gameItemId = 1;
        string description = "Test damage";
        var gameItem = new GameItem { Id = gameItemId, Damages = new List<Damage>() };
        mockGameItemRepository.Setup(repo => repo.GetGameItem(gameItemId)).ReturnsAsync(gameItem);

        // Act
        var result = await addDamageUseCase.Execute(gameItemId, description);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Single(gameItem.Damages);
        Assert.Equal(description, gameItem.Damages[0].Description);
    }
}
