using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Domain.Contexts.Catalog.UseCases;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class UpdateDamageUseCaseTests
{
    private readonly Mock<IGameItemRepository> _gameItemRepositoryMock;
    private readonly UpdateDamageUseCase _updateDamageUseCase;

    public UpdateDamageUseCaseTests()
    {
        _gameItemRepositoryMock = new Mock<IGameItemRepository>();
        _updateDamageUseCase = new UpdateDamageUseCase(_gameItemRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameItemNotFound()
    {
        // Arrange
        int gameItemId = 1;
        int damageId = 1;
        string description = "Updated description";
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync((GameItem?)null);

        // Act
        var result = await _updateDamageUseCase.Execute(gameItemId, damageId, description);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<GameNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenDamageNotFound()
    {
        // Arrange
        int gameItemId = 1;
        int damageId = 1;
        string description = "Updated description";
        var gameItem = new GameItem { Id = gameItemId, Damages = new List<Damage>() };
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync(gameItem);

        // Act
        var result = await _updateDamageUseCase.Execute(gameItemId, damageId, description);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<DamageNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenDamageIsUpdated()
    {
        // Arrange
        int gameItemId = 1;
        int damageId = 1;
        string description = "Updated description";
        var damage = new Damage(damageId, "Old description");
        var gameItem = new GameItem { Id = gameItemId, Damages = new List<Damage> { damage } };
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync(gameItem);

        // Act
        var result = await _updateDamageUseCase.Execute(gameItemId, damageId, description);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(description, gameItem.Damages.First(d => d.Id == damageId).Description);
    }
}




