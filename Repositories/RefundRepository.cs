using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Adapters.Database;
using Webbpay.Api.PaymentService.Entities;

namespace Webbpay.Api.PaymentService.Repositories
{
    public class RefundRepository : IRefundRepository
    {
        private readonly PaymentDbContext _dbContext;

        public RefundRepository(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RefundTransaction> Get(Guid refundTransactionId)
        {
            return await _dbContext.RefundTransactions
                .Include(c => c.PaymentTransaction)
                .ThenInclude(c => c.PaymentLink)
                .FirstOrDefaultAsync(f => f.Id == refundTransactionId);
        }

        public async Task<RefundTransaction> Create(RefundTransaction refund)
        {
            await _dbContext.RefundTransactions.AddAsync(refund);
            await _dbContext.SaveChangesAsync();
            _dbContext.Entry(refund).State = EntityState.Detached;
            refund = await _dbContext.RefundTransactions
                .Include(c => c.PaymentTransaction)
                .ThenInclude(f => f.PaymentLink)                
                
                .FirstOrDefaultAsync(f => f.Id == refund.Id);
            return refund;
        }

        public async Task<RefundTransaction> Update(RefundTransaction refund)
        {
            _dbContext.RefundTransactions.Attach(refund);
            _dbContext.Entry(refund).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return await _dbContext.RefundTransactions
                .Include(c => c.PaymentTransaction)
                .ThenInclude(c => c.PaymentLink)
                .FirstOrDefaultAsync(f => f.Id == refund.Id);
        }

        public async Task<RefundEvent> CreateEvent(RefundEvent @event)
        {
            await _dbContext.RefundEvents.AddAsync(@event);
            await _dbContext.SaveChangesAsync();
            _dbContext.Entry(@event).State = EntityState.Detached;
            return @event;
        }

        public async Task<IList<RefundTransaction>> RefundsByPaymentTransaction(Guid paymentTransactionId)
        {
            return await _dbContext.RefundTransactions.Where(r => r.PaymentTransactionId == paymentTransactionId).ToListAsync();
        }


    }
}
