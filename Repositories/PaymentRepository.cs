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
        .Include(pl => pl.PaymentTransactions)
        .SingleAsync(pl => pl.PaymentLinkRef == paymentLinkRef);
    }

    public async Task CreatePaymentLinkAsync(PaymentLink paymentLink)
    {
      await _dbContext.PaymentLink.AddAsync(paymentLink);
      await _dbContext.SaveChangesAsync();
    }

    public async Task CreatePaymentTransactionAsync(PaymentTransaction paymentTransaction, string paymentLinkRef)
    {
      var paymentLink = await GetPaymentLinkAsync(paymentLinkRef);
      if (paymentLink == null)
        return;

      _dbContext.PaymentTransaction.Add(paymentTransaction);
      paymentLink.PaymentTransactions.Add(paymentTransaction);
      _dbContext.SaveChanges();
    }

    public async Task<List<PaymentTransaction>> GetPaymentTransactionAsync(string paymentLinkRef)
    {
      var paymentLink = await GetPaymentLinkAsync(paymentLinkRef);
      return paymentLink.PaymentTransactions;
    }
  }
}
