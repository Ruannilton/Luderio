using Luderia.Domain.Contexts.Customers.Models;

namespace Luderia.Presentation.Contexts.Customers;

public class CreateCustomerRequest
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Address Address { get; set; }
}