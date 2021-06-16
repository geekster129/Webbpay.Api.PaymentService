using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Adapters.Database;
using Webbpay.Api.PaymentService.Entities;

namespace Webbpay.Api.PaymentService.Repositories
{
    public class TransactionEventRepository : ITransactionEventRepository
    {
        private readonly PaymentDbContext _dbContext;

        public TransactionEventRepository(PaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TransactionEvent> Create(TransactionEvent @event)
        {
            await _dbContext.TransactionEvents.AddAsync(@event);
            await _dbContext.SaveChangesAsync();
            _dbContext.Entry(@event).State = EntityState.Detached;
            return await _dbContext.TransactionEvents
                .Include(c => c.Payment)
                .ThenInclude(c => c.PaymentLink)
                .FirstOrDefaultAsync(c => c.Id == @event.Id);
        }

        public async Task<TransactionEvent> GetLatestEvent(Guid paymentTransactionId)
        {
            var query = _dbContext.TransactionEvents
                .Where(e => e.PaymentTransactionId == paymentTransactionId)
                .OrderByDescending(e => e.Created)
                .Include(c => c.Payment)
                .ThenInclude(c => c.PaymentLink);

            return await query.FirstOrDefaultAsync();
        }
    }
}
