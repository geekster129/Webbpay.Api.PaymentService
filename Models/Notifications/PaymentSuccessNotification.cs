using MediatR;
using System.Collections.Generic;
using System.Linq;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Notifications
{
    public class PaymentSuccessNotification : INotification
    {
        public PaymentSuccessNotification(PaymentTransactionDto payment)
        {
            Payment = payment;
        }

        public PaymentTransactionDto Payment { get; }
    }
}
