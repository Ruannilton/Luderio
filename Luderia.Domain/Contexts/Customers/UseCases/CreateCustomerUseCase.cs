using Luderia.Domain.Contexts.Customers.Abstractions.Queries;
using Luderia.Domain.Contexts.Customers.Abstractions.Repositories;
using Luderia.Domain.Contexts.Customers.Abstractions.UseCases;
using Luderia.Domain.Contexts.Customers.Models;

namespace Luderia.Domain.Contexts.Customers.UseCases;
internal class CreateCustomerUseCase : ICreateCustomerUseCase
{
    private readonly ICustomerRepository customerRepository;
    private readonly ICustomerAlreadyExistsQuery customerAlreadyExistsQuery;

    public CreateCustomerUseCase(ICustomerRepository customerRepository, ICustomerAlreadyExistsQuery customerAlreadyExistsQuery)
    {
        this.customerRepository = customerRepository;
        this.customerAlreadyExistsQuery = customerAlreadyExistsQuery;
    }
    public async Task<Result> Execute(CreateCustomerMessage message)
    {
        var customer = new Customer()
        {
            Active = true,
            Address = message.Address,
            Cpf = message.Cpf,
            Email = message.Email,
            Name = message.Name,
            Phone = message.Phone
        };

        var existentCustomer = await customerAlreadyExistsQuery.Execute(customer.Email, customer.Cpf, customer.Phone);
        if (existentCustomer != null)
        {
            var error = GetValidationError(existentCustomer, customer)!;
            return Result.Failure(error);
        }

        var result = customerRepository.Create(customer);

        return result;
    }


    DomainError? GetValidationError(Customer existent, Customer newCustomer)
    {
        if (existent.Email == newCustomer.Email)
        {
            return new CustomerEmailAlreadExistsError();
        }
        if (existent.Cpf == newCustomer.Cpf)
        {
            return new CustomerCpfAlreadyExists();
        }
        if (existent.Phone == newCustomer.Phone)
        {
            return new CustomerPhoneAlreadyExists();
        }
        return null;
    }
}