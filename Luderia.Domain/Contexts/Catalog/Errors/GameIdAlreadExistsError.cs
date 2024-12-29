﻿public record GameIdAlreadExistsError() : DomainError(nameof(GameIdAlreadExistsError), "Game id already exists");