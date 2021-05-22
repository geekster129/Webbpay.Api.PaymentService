﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;

namespace Webbpay.Api.PaymentService.Repositories
{
  public interface IPaymentRepository
  {
    Task CreatePaymentLinkAsync(PaymentLink paymentLink);
    Task<PaymentLink> GetPaymentLinkAsync(string paymentLinkRef);
    Task CreatePaymentTransactionAsync(PaymentTransaction paymentTransaction);
    Task<List<PaymentTransaction>> GetPaymentTransactionAsync(string paymentTransaction);
  }
}