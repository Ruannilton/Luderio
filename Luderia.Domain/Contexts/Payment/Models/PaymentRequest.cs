using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luderia.Domain.Contexts.Payment.Models;
public class PaymentRequest
{
    public int OrderId { get; set; }
    public string TransactionId { get; set; }
    public string PixCopyPaste { get; set; }
}

public struct CreatePaymentRequestMessage
{
    public int OrderId { get; set; }
    public string Cpf { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
}