using Luderia.Domain.Contexts.Customers.Abstractions.Queries;
using Luderia.Domain.Contexts.Customers.Abstractions.UseCases;
using Luderia.Domain.Contexts.Customers.Models;

namespace Luderia.Domain.Contexts.Customers.UseCases;

internal class GetCustomerUseCase : IGetCustomerUseCase
{
    private readonly IGetCustomerQuery getCustomerQuery;

    public GetCustomerUseCase(IGetCustomerQuery getCustomerQuery)
    {
        this.getCustomerQuery = getCustomerQuery;
    }
    public async Task<Result<Customer>> Execute(Guid id)
    {
        var customer = await getCustomerQuery.Execute(id);

        if (customer == null)
        {
            return Result.Failure(new CustomerNotFoundError());
        }

        return Result.Success(customer);
    }
}
