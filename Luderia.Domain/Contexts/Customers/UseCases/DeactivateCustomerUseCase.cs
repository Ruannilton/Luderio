using Luderia.Domain.Contexts.Customers.Abstractions.Queries;
using Luderia.Domain.Contexts.Customers.Abstractions.Repositories;
using Luderia.Domain.Contexts.Customers.Abstractions.UseCases;

namespace Luderia.Domain.Contexts.Customers.UseCases;

internal class DeactivateCustomerUseCase : IDeactivateCustomerUseCase
{
    private readonly ICustomerRepository customerRepository;
    private readonly ICustomerExistsQuery customerExistsQuery;

    public DeactivateCustomerUseCase(ICustomerRepository customerRepository, ICustomerExistsQuery customerExistsQuery)
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

        customer!.Deactivate();

        return Result.Success();
    }
}
