public record GameNotFoundError() : DomainError(nameof(GameNotFoundError), "Game not found");
