using Luderia.Domain.Contexts.Customers.Abstractions.UseCases;
using Luderia.Domain.Contexts.Customers.Models;
using Luderia.Presentation.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Luderia.Presentation.Contexts.Customers;

[ApiController]
[Route("customer")]
public class CustomerController : ControllerBase
{
    [HttpGet("/{id}")]
    public async Task<ActionResult<Customer>> GetCustomer([FromServices] IGetCustomerUseCase useCase, Guid id)
    {
        var customerResult = await useCase.Execute(id);

        if (customerResult.IsFailure)
        {
            return this.ProblemResponse(customerResult);
        }

        var customer = customerResult.Value;

        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult> AddCustomer([FromServices] ICreateCustomerUseCase useCase, [FromBody] CreateCustomerRequest request)
    {
        var message = new CreateCustomerMessage
        {
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            Address = request.Address,
            Cpf = request.Cpf,
        };
        var customerResult = await useCase.Execute(message);

        if (customerResult.IsFailure)
        {
            return this.ProblemResponse(customerResult);
        }

        return Created();
    }

    [HttpPut("/{id}")]
    public async Task<ActionResult> UpdateCustomer([FromServices] IUpdateCustomerUseCase useCase, Guid id, [FromBody] CostumerUpateMessage request)
    {
        var message = new CostumerUpateMessage
        {
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            Cpf = request.Cpf,
        };

        var customerResult = await useCase.Execute(id, message);

        if (customerResult.IsFailure)
        {
            return this.ProblemResponse(customerResult);
        }

        return NoContent();
    }

    [HttpPut("/{id}/address")]
    public async Task<ActionResult> UpdateCustomerAddress([FromServices] IUpdateCustomerAddressUseCase useCase, Guid id, [FromBody] AddressUpdateRequest request)
    {
        States? state = request.State is null ? null : Enum.Parse<States>(request.State);

        var message = new AddressUpdateMessage(
            request.Street,
            request.Number,
            request.Complement,
            request.Neighborhood,
            request.City,
            state,
            request.Country,
            request.ZipCode
            );

        var customerResult = await useCase.Execute(id, message);

        if (customerResult.IsFailure)
        {
            return this.ProblemResponse(customerResult);
        }
        return NoContent();
    }

    [HttpPut("/{id}/activate")]
    public async Task<ActionResult> ActivateCustomer([FromServices] IActivateCustomerUseCase useCase, Guid id)
    {
        var customerResult = await useCase.Execute(id);
        if (customerResult.IsFailure)
        {
            return this.ProblemResponse(customerResult);
        }
        return NoContent();
    }

    [HttpPut("/{id}/deactivate")]
    public async Task<ActionResult> DeactivateCustomer([FromServices] IDeactivateCustomerUseCase useCase, Guid id)
    {
        var customerResult = await useCase.Execute(id);
        if (customerResult.IsFailure)
        {
            return this.ProblemResponse(customerResult);
        }
        return NoContent();
    }
}
