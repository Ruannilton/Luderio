using Luderia.Domain.Contexts.Payment.Abstraction.Repositories;
using Luderia.Domain.Contexts.Payment.Abstraction.UseCases;
using Luderia.Domain.Contexts.Payment.Errors;
using Luderia.Domain.Contexts.Payment.Models;

namespace Luderia.Domain.Contexts.Payment.UseCases;
internal class GetPaymentRequestUseCase : IGetPaymentRequestUseCase
{
    private readonly IPaymentRequestRepository paymentRequestRepository;
    public GetPaymentRequestUseCase(IPaymentRequestRepository paymentRequestRepository)
    {
        this.paymentRequestRepository = paymentRequestRepository;
    }
    public async Task<Result<PaymentRequest>> Execute(int orderId)
    {
        var paymentRequest = await paymentRequestRepository.GetPayment(orderId);

        if (paymentRequest == null)
        {
            return Result.Failure(new PaymentNotFoundError());
        }

        return Result.Success(paymentRequest);
    }
}
