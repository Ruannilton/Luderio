using Luderia.Domain.Contexts.Customers.Abstractions.Repositories;
using Luderia.Domain.Contexts.Customers.Abstractions.UseCases;
using Luderia.Domain.Contexts.Customers.Models;

namespace Luderia.Domain.Contexts.Customers.UseCases;

internal class UpdateCustomerUseCase : IUpdateCustomerUseCase
{
    private readonly ICustomerRepository customerRepository;

    public UpdateCustomerUseCase(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }
    public async Task<Result> Execute(Guid customerId, CostumerUpateMessage message)
    {
        var customer = await customerRepository.Get(customerId);

        if (customer == null)
        {
            return Result.Failure(new CustomerNotFoundError());
        }

        customer!.Update(message);

        return Result.Success();
    }
}