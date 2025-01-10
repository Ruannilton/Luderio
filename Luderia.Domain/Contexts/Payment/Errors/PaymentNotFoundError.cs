using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luderia.Domain.Contexts.Payment.Errors;
public record PaymentNotFoundError() : DomainError(nameof(PaymentNotFoundError), "The order has not payment requested");
