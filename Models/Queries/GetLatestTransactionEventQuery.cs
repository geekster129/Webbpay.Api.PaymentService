using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Queries
{
    public class GetLatestTransactionEventQuery : IRequest<TransactionEventDto>
    {

        public GetLatestTransactionEventQuery(Guid paymentTransactionId)
        {
            PaymentTransactionId = paymentTransactionId;
        }

        public Guid PaymentTransactionId { get; }
    }
}
