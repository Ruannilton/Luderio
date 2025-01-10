using Luderia.Domain.Contexts.Payment.Models;

namespace Luderia.Domain.Contexts.Payment.Abstraction.Repositories;
public interface IPaymentRequestRepository
{
    Task<PaymentRequest> Create(PaymentRequest paymentRequest);
    Task<PaymentRequest> GetPayment(int orderId);
}
