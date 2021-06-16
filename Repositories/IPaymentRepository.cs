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
        Task<PagedResult<PaymentLink>> SearchPaymentLinkAsync(
            PaymentLinkStatus status = PaymentLinkStatus.Active,
            int page = 1,
            int pageSize = 10);

        Task<PaymentTransaction> CreatePaymentTransactionAsync(PaymentTransaction paymentTransaction);
        Task<List<PaymentTransaction>> GetPaymentTransactionsAsync(string paymentTransaction);
        Task<PaymentTransaction> GetPaymentTransactionByOrderNo(string orderNo);
        Task<PaymentTransaction> GetPaymentTransactionById(Guid id);
        Task<PaymentTransaction> UpdatePaymentTransactionAsync(PaymentTransaction paymentTransaction);

    }
}