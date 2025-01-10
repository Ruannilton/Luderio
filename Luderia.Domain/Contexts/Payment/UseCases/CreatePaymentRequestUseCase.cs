using Luderia.Domain.Contexts.Payment.Abstraction.Gateway;
using Luderia.Domain.Contexts.Payment.Abstraction.UseCases;
using Luderia.Domain.Contexts.Payment.Models;

namespace Luderia.Domain.Contexts.Payment.UseCases;
internal class CreatePaymentRequestUseCase : ICreatePaymentRequestUseCase
{
    private readonly IPaymentService paymentService;

    public CreatePaymentRequestUseCase(IPaymentService paymentService)
    {
        this.paymentService = paymentService;
    }
    public async Task<Result<PaymentRequest>> Execute(CreatePaymentRequestMessage message)
    {
        var createPaymentResponse = await paymentService.CreateCharge(message.Name,message.Cpf,message.Value);

        if (createPaymentResponse.IsFailure)
        {
            return Result.Failure(createPaymentResponse.Error!);
        }

        var chargeResponse = createPaymentResponse.Value;

        var paymentRequest = new PaymentRequest()
        {
            OrderId = message.OrderId,
            TransactionId = chargeResponse.TransactionId,
            PixCopyPaste = chargeResponse.PixCode,
        };

        return Result.Success(paymentRequest);
    }
}
