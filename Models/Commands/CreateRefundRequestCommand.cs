using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Commands
{
    public class CreateRefundRequestCommand : IRequest<RefundTransactionDto>
    {
        public CreateRefundRequestCommand(
            RefundRequestModel request)
        {
            Request = request;
        }

        public RefundRequestModel Request { get; }
    }
}
