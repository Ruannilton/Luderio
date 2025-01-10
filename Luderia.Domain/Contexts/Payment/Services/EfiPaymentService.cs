using Luderia.Domain.Contexts.Payment.Abstraction.Gateway;

namespace Luderia.Domain.Contexts.Payment.Services;
internal class EfiPaymentService : IPaymentService
{
    public async Task<Result<ChargeResponse>> CreateCharge(string name, string cpf, double value)
    {
        await Task.CompletedTask;

        return Result.Success(new ChargeResponse());
    }

    public async Task<Result<ChargeResponse>> DetailCharge(string transactionId)
    {
        await Task.CompletedTask;

        return Result.Success(new ChargeResponse());
    }
}
