using Luderia.Domain.Contexts.Catalog.Abstractions.Repositories;
using Luderia.Domain.Contexts.Catalog.Models;
using Luderia.Domain.Contexts.Catalog.UseCases;
using Moq;

namespace Luderia.UnitTest.Catalog;
public class RemoveDamageUseCaseTests
{
    private readonly Mock<IGameItemRepository> _gameItemRepositoryMock;
    private readonly RemoveDamageUseCase _removeDamageUseCase;

    public RemoveDamageUseCaseTests()
    {
        _gameItemRepositoryMock = new Mock<IGameItemRepository>();
        _removeDamageUseCase = new RemoveDamageUseCase(_gameItemRepositoryMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnFailure_WhenGameItemNotFound()
    {
        // Arrange
        int gameItemId = 1;
        int damageId = 1;
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync((GameItem?)null);

        // Act
        var result = await _removeDamageUseCase.Execute(gameItemId, damageId);

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
        var gameItem = new GameItem { Id = gameItemId, Damages = new List<Damage>() };
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync(gameItem);

        // Act
        var result = await _removeDamageUseCase.Execute(gameItemId, damageId);

        // Assert
        Assert.True(result.IsFailure);
        Assert.IsType<DamageNotFoundError>(result.Error);
    }

    [Fact]
    public async Task Execute_ShouldReturnSuccess_WhenDamageIsRemoved()
    {
        // Arrange
        int gameItemId = 1;
        int damageId = 1;
        var damage = new Damage(damageId, "");
        var gameItem = new GameItem { Id = gameItemId, Damages = new List<Damage> { damage } };
        _gameItemRepositoryMock.Setup(x => x.GetGameItem(gameItemId)).ReturnsAsync(gameItem);

        // Act
        var result = await _removeDamageUseCase.Execute(gameItemId, damageId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.DoesNotContain(damage, gameItem.Damages);
    }
}


