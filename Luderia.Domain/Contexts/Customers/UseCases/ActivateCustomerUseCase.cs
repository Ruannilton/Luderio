using Luderia.Domain.Contexts.Customers.Abstractions.Queries;
using Luderia.Domain.Contexts.Customers.Abstractions.Repositories;
using Luderia.Domain.Contexts.Customers.Abstractions.UseCases;

namespace Luderia.Domain.Contexts.Customers.UseCases;

internal class ActivateCustomerUseCase : IActivateCustomerUseCase
{
    private readonly ICustomerRepository customerRepository;
    private readonly ICustomerExistsQuery customerExistsQuery;
    public ActivateCustomerUseCase(ICustomerRepository customerRepository, ICustomerExistsQuery customerExistsQuery)
    {
        this.customerRepository = customerRepository;
        this.customerExistsQuery = customerExistsQuery;
    }
    public async Task<Result> Execute(Guid id)
    {
        if (await customerExistsQuery.Execute(id) == false)
        {
            return Result.Failure(new CustomerNotFoundError());
        }
        var customer = await customerRepository.Get(id);

        customer!.Activate();

        return Result.Success();
    }
}
