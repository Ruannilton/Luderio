public record OutOfStockError() : DomainError(nameof(OutOfStockError), "Game id out of stock");

public record GameItemAlreadyAvailableError() : DomainError(nameof(GameItemAlreadyAvailableError), "Game item already available");

public record DamageNotFoundError() : DomainError(nameof(DamageNotFoundError), "Damage not found");