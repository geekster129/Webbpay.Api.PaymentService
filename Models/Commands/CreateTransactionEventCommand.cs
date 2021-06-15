using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Commands
{
    public class CreateTransactionEventCommand : IRequest<TransactionEventDto>
    {
        public CreateTransactionEventCommand(CreateTransactionEventModel @event)
        {
            Event = @event;
        }

        public CreateTransactionEventModel Event { get; }
    }
}
