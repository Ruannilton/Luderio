public record CustomerPhoneAlreadyExists() : DomainError(nameof(CustomerPhoneAlreadyExists), "Phone alredy registered");
