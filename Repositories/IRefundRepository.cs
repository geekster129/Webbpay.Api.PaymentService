using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Repositories
{
    public interface IRefundRepository
    {
        Task<RefundTransaction> Get(Guid refundTransactionId);
        Task<RefundTransaction> Create(RefundTransaction refund);
        Task<RefundTransaction> Update(RefundTransaction refund);
        Task<PagedResult<RefundTransaction>> SearchAll(RefundStatus status, int page, int pageSize);

        Task<RefundEvent> CreateEvent(RefundEvent @event);

        Task<IList<RefundTransaction>> RefundsByPaymentTransaction(Guid paymentTransactionId);

    }
}
