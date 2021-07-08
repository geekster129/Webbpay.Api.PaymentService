using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Queries
{
    public class GetPaymentTransactionQuery : IRequest<PaymentTransactionDto>
    {
        public GetPaymentTransactionQuery(Guid transactionId) 
        {
            TransactionId = transactionId;
        }

        public Guid TransactionId { get; }
    }
}
