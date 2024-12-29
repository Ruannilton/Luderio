
namespace Luderia.Domain.Contexts.Customers.Models;

public record AddressUpdateMessage(string? Street, string? Number, string? Complement, string? Neighborhood, string? City, States? State, string? Country, string? ZipCode);