using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Notifications
{
    public class TransactionCreatedEvent : INotification
    {
        public TransactionCreatedEvent(
            PaymentTransactionDto paymentTransaction)
        {
            PaymentTransaction = paymentTransaction;
        }

        public PaymentTransactionDto PaymentTransaction { get; }
    }
}
