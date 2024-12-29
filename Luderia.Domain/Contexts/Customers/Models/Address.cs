
namespace Luderia.Domain.Contexts.Customers.Models;

public enum States
{
    AC, AL, AP, AM, BA, CE, DF, ES, GO, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO
}

public record Address(string Street, string Number, string Complement, string Neighborhood, string City, States State, string Country, string ZipCode);
