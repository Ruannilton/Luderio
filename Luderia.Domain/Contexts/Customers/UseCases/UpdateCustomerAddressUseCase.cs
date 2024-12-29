using Luderia.Domain.Contexts.Customers.Abstractions.Repositories;
using Luderia.Domain.Contexts.Customers.Abstractions.UseCases;
using Luderia.Domain.Contexts.Customers.Models;

namespace Luderia.Domain.Contexts.Customers.UseCases;

internal class UpdateCustomerAddressUseCase : IUpdateCustomerAddressUseCase
{
    private readonly ICustomerRepository customerRepository;

    public UpdateCustomerAddressUseCase(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }
    public async Task<Result> Execute(Guid customerId, AddressUpdateMessage address)
    {
        var customer = await customerRepository.Get(customerId);

        if (customer == null)
        {
            return Result.Failure(new CustomerNotFoundError());
        }

        customer!.UpdateAddress(address);

        return Result.Success();
    }
}
