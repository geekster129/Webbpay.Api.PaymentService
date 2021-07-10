using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Commands
{
    public class CreateRefundEventCommand : IRequest<RefundEventDto>
    {
        public CreateRefundEventCommand(CreateRefundEventModel @event)
        {
            Event = @event;
        }

        public CreateRefundEventModel Event { get; }
    }
}
