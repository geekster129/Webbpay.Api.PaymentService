using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Notifications
{
    public class TransactionEventCreatedNotification : INotification
    {
        public TransactionEventCreatedNotification(TransactionEventDto @event)
        {
            Event = @event;
        }

        public TransactionEventDto Event { get; }
    }
}
