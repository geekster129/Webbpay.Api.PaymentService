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
              .SingleOrDefaultAsync(pl => pl.PaymentLinkRef == paymentLinkRef);
        }

        public async Task<PaymentLink> CreatePaymentLinkAsync(PaymentLink paymentLink)
        {
            await _dbContext.PaymentLink.AddAsync(paymentLink);
            await _dbContext.SaveChangesAsync();
            return await GetPaymentLinkAsync(paymentLink.PaymentLinkRef);
        }

        public async Task CreatePaymentTransactionAsync(PaymentTransaction paymentTransaction)
        {
            var paymentLink = await _dbContext.PaymentLink.FindAsync(paymentTransaction.PaymentLinkId);
            if (paymentLink == null)
                return;

            _dbContext.PaymentTransaction.Add(paymentTransaction);

            paymentLink.PaymentTransactions.Add(paymentTransaction);
            paymentLink.Updated = DateTime.Now;
            paymentLink.UpdatedBy = paymentTransaction.CreatedBy;

            _dbContext.SaveChanges();
        }

        public async Task<List<PaymentTransaction>> GetPaymentTransactionAsync(string paymentLinkRef)
        {
            var paymentLink = await GetPaymentLinkAsync(paymentLinkRef);
            return paymentLink.PaymentTransactions;
        }

        public async Task<PagedResult<PaymentLink>> SearchPaymentLinkAsync(
            PaymentLinkStatus status = PaymentLinkStatus.Active, 
            int page = 1, 
            int pageSize = 10)
        {
            var query = _dbContext.PaymentLink.Where(p => p.Status == PaymentLinkStatus.Active);

            return new PagedResult<PaymentLink>
            {
                Total = await query.CountAsync(),
                Items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync()
            };
        }

        public async Task<PaymentTransaction> GetPaymentTransactionByOrderNo(string orderNo)
        {
            return await _dbContext.PaymentTransaction.Include(t => t.PaymentLink)
                .FirstOrDefaultAsync(t => t.PaymentOrderNo == orderNo);
        }
    }
}
