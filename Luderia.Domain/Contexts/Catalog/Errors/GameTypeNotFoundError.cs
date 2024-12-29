public record GameTypeNotFoundError() : DomainError(nameof(GameTypeNotFoundError), "Game type not found");
