﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;

namespace Webbpay.Api.PaymentService.Repositories
{
    public interface IRefundRepository
    {
        Task<RefundTransaction> Create(RefundTransaction refund);

        Task<RefundEvent> CreateEvent(RefundEvent @event);

        Task<IList<RefundTransaction>> RefundsByPaymentTransaction(Guid paymentTransactionId);

    }
}