using Luderia.Domain.Contexts.Customers.Models;

namespace Luderia.Domain.Contexts.Customers.Abstractions.UseCases;

public interface IUpdateCustomerAddressUseCase
{
    Task<Result> Execute(Guid customerId, AddressUpdateMessage address);
}