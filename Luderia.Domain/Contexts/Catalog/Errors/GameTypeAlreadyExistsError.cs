public record GameTypeAlreadyExistsError() : DomainError(nameof(GameTypeAlreadyExistsError), "Game type already exists");
