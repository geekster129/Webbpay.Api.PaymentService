using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;

namespace Webbpay.Api.PaymentService.Repositories
{
    public interface ITransactionEventRepository
    {
        Task<TransactionEvent> Create(TransactionEvent @event);

        Task<TransactionEvent> GetLatestEvent(Guid paymentTransactionId);
    }
}
