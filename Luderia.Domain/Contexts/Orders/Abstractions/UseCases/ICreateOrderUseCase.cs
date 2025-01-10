using Luderia.Domain.Contexts.Orders.Models;

namespace Luderia.Domain.Contexts.Orders.Abstractions.UseCases;
public interface ICreateOrderUseCase
{
    Task<Result> Execute(CreateOrderMessage message);
}
