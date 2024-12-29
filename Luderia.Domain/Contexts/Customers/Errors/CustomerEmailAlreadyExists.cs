public record CustomerEmailAlreadExistsError() : DomainError(nameof(CustomerEmailAlreadExistsError), "Email alredy registered");

public record CustomerNotFoundError() : DomainError(nameof(CustomerNotFoundError), "Customer not found");