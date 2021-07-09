using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Repositories
{
    public interface IPaymentRepository
    {
        Task<PaymentLink> CreatePaymentLinkAsync(PaymentLink paymentLink);
        Task<PaymentLink> GetPaymentLinkAsync(string paymentLinkRef);
        Task<IList<PaymentLink>> GetPaymentLinksAsync(Guid storeId, IEnumerable<Guid> paymentLinkIds);
        Task<PagedResult<PaymentLink>> SearchPaymentLinkAsync(
            Guid storeId,
            PaymentLinkStatus status = PaymentLinkStatus.Active,
            Guid? productId = null,
            int page = 1,
            int pageSize = 10);

        Task<PagedResult<PaymentTransaction>> SearchPaymentTransactionAsync(
            Guid storeId,
            PaymentStatus? paymentStatus = PaymentStatus.ACCEPTED,
            Guid? paymentLinkId = null,
            Guid? productId = null,
            int page = 1,
            int pageSize = 10
            );
        Task<PaymentTransaction> CreatePaymentTransactionAsync(PaymentTransaction paymentTransaction);

        Task<List<PaymentTransaction>> GetPaymentTransactionsByStoreAsync(Guid storeId);
        Task<List<PaymentTransaction>> GetPaymentTransactionsAsync(string paymentTransaction);
        Task<PaymentTransaction> GetPaymentTransactionByOrderNo(string orderNo);
        Task<PaymentTransaction> GetPaymentTransactionById(Guid id);
        
        Task<PaymentTransaction> UpdatePaymentTransactionAsync(PaymentTransaction paymentTransaction);

    }
}