namespace Luderia.Domain.Contexts.Customers.Models;
public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Address Address { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }

    public void Deactivate()
    {
        Active = false;
    }

    public void Activate()
    {
        Active = true;
    }

    internal void UpdateAddress(AddressUpdateMessage address)
    {
        if (!string.IsNullOrEmpty(address.Street))
            Address = Address with { Street = address.Street };

        if (!string.IsNullOrEmpty(address.Number))
            Address = Address with { Number = address.Number };

        if (!string.IsNullOrEmpty(address.Complement))
            Address = Address with { Complement = address.Complement };

        if (!string.IsNullOrEmpty(address.Neighborhood))
            Address = Address with { Neighborhood = address.Neighborhood };

        if (!string.IsNullOrEmpty(address.City))
            Address = Address with { City = address.City };

        if (address.State != null)
            Address = Address with { State = address.State.Value };

        if (!string.IsNullOrEmpty(address.Country))
            Address = Address with { Country = address.Country };

    }

    internal void Update(CostumerUpateMessage message)
    {
        if (!string.IsNullOrEmpty(message.Name))
            Name = message.Name;

        if (!string.IsNullOrEmpty(message.Cpf))
            Cpf = message.Cpf;

        if (!string.IsNullOrEmpty(message.Email))
            Email = message.Email;

        if (!string.IsNullOrEmpty(message.Phone))
            Phone = message.Phone;
    }
}
