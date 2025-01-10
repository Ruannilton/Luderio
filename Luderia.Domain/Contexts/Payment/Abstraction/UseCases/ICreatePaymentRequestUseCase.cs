using Luderia.Domain.Contexts.Payment.Models;

namespace Luderia.Domain.Contexts.Payment.Abstraction.UseCases;
public interface ICreatePaymentRequestUseCase
{
    Task<Result<PaymentRequest>> Execute(CreatePaymentRequestMessage message);
}

