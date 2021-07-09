using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Notifications
{
    public class RefundRequestCreatedNotification : INotification
    {
        public RefundRequestCreatedNotification(
            RefundTransactionDto refund
            )
        {
            Refund = refund;
        }

        public RefundTransactionDto Refund { get; }
    }
}
