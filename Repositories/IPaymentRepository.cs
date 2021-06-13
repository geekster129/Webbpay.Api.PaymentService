﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;

namespace Webbpay.Api.PaymentService.Repositories
{
    public interface IPaymentRepository
    {
        Task<PaymentLink> CreatePaymentLinkAsync(PaymentLink paymentLink);
        Task<PaymentLink> GetPaymentLinkAsync(string paymentLinkRef);
        Task CreatePaymentTransactionAsync(PaymentTransaction paymentTransaction, string paymentLinkRef);
        Task<List<PaymentTransaction>> GetPaymentTransactionAsync(string paymentTransaction);
        Task<PagedResult<PaymentLink>> SearchPaymentLinkAsync(
            PaymentLinkStatus status = PaymentLinkStatus.Active,
            int page = 1,
            int pageSize = 10);
    }
}