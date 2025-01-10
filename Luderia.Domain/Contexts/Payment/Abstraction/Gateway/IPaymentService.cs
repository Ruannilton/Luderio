namespace Luderia.Domain.Contexts.Payment.Abstraction.Gateway;
public interface IPaymentService
{
    Task<Result<ChargeResponse>> CreateCharge(string name, string cpf, double value);
    Task<Result<ChargeResponse>> DetailCharge(string transactionId);
}

public struct ChargeResponse
{
    public string TransactionId { get; set; }
    public string PixCode { get; set; }
    public double Value { get; set; }
    public string JsonExtenstions { get; set; }
}