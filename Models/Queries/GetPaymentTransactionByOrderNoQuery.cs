using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Queries
{
    public class GetPaymentTransactionByOrderNoQuery : IRequest<PaymentTransactionDto>
    {
        public GetPaymentTransactionByOrderNoQuery(
            string orderNo
            )
        {
            OrderNo = orderNo;
        }

        public string OrderNo { get; }
    }
}
