using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Adapters.Database;

namespace Webbpay.Api.PaymentService.Repositories
{
  public class PaymentRepository : IPaymentRepository
  {
    private readonly PaymentDbContext _dbContext;

    public PaymentRepository(PaymentDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<PaymentLink> GetPaymentLinkAsync(string paymentLinkRef)
    {
      return await _dbContext.PaymentLink
        .SingleAsync(pl => pl.PaymentLinkRef == paymentLinkRef);
    }

    public async Task CreatePaymentLinkAsync(PaymentLink paymentLink)
    {
      await _dbContext.PaymentLink.AddAsync(paymentLink);
    }

    public async Task CreatePaymentTransactionAsync(PaymentTransaction paymentTransaction)
    {
      await _dbContext.PaymentTransaction.AddAsync(paymentTransaction);
    }

    public async Task<List<PaymentTransaction>> GetPaymentTransactionAsync(string paymentLinkRef)
    {
      var paymentLink = await GetPaymentLinkAsync(paymentLinkRef);
      return paymentLink.PaymentTransactions;
    }
  }
}
