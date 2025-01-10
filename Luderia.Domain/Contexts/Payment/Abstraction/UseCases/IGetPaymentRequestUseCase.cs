using Luderia.Domain.Contexts.Payment.Models;

namespace Luderia.Domain.Contexts.Payment.Abstraction.UseCases;

public interface IGetPaymentRequestUseCase
{
    Task<Result<PaymentRequest>> Execute(int orderId);
}

