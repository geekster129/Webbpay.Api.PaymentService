using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Adapters.Database;
using Webbpay.Api.PaymentService.Entities.Enums;

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

        public async Task<PaymentTransaction> CreatePaymentTransactionAsync(PaymentTransaction paymentTransaction)
        {
            var paymentLink = await _dbContext.PaymentLink.FindAsync(paymentTransaction.PaymentLinkId);
            if (paymentLink == null)
                return null;

            _dbContext.PaymentTransaction.Add(paymentTransaction);

            paymentLink.PaymentTransactions.Add(paymentTransaction);
            paymentLink.Updated = DateTime.Now;
            paymentLink.UpdatedBy = paymentTransaction.CreatedBy;

            _dbContext.SaveChanges();
            paymentTransaction.PaymentLink = paymentLink;
            return paymentTransaction;
        }

        public async Task<List<PaymentTransaction>> GetPaymentTransactionsByStoreAsync(Guid storeId)
        {
            return await _dbContext.PaymentLink
              .Include(pl => pl.PaymentTransactions)
              .Where(pl => pl.StoreId == storeId)
              .SelectMany(pl => pl.PaymentTransactions)
              .ToListAsync();
        }

        public async Task<List<PaymentTransaction>> GetPaymentTransactionsAsync(string paymentLinkRef)
        {
            var paymentLink = await GetPaymentLinkAsync(paymentLinkRef);
            return paymentLink.PaymentTransactions;
        }

        public async Task<PagedResult<PaymentLink>> SearchPaymentLinkAsync(
            Guid storeId,
            PaymentLinkStatus status = PaymentLinkStatus.Active,
            Guid? productId = null,
            int page = 1, 
            int pageSize = 10,
            bool forceCheckExpired = false)
        {
            var query = _dbContext.PaymentLink.AsQueryable();
            query = query.Where(p => p.StoreId == storeId && p.Status == status);


            if (productId.HasValue)
                query = query.Where(p => p.ProductId == productId);

            if(forceCheckExpired)
            {
                query = query.Where(p => p.ExpiryDate.HasValue && p.ExpiryDate <= DateTime.UtcNow);
            }

            return new PagedResult<PaymentLink>
            {
                Total = await query.CountAsync(),
                Items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync()
            };
        }

        public async Task<PaymentTransaction> GetPaymentTransactionByOrderNo(string orderNo)
        {
            return await _dbContext.PaymentTransaction.Include(t => t.PaymentLink)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.PaymentOrderNo == orderNo);
        }

        public async Task<PaymentTransaction> GetPaymentTransactionById(Guid id)
        {
            return await _dbContext.PaymentTransaction
                .AsNoTracking()
                .Include(t => t.PaymentLink)
               .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<PaymentTransaction> UpdatePaymentTransactionAsync(PaymentTransaction paymentTransaction)
        {
            _dbContext.PaymentTransaction.Attach(paymentTransaction);
            _dbContext.Entry(paymentTransaction).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return paymentTransaction;
        }

        public async Task<PagedResult<PaymentTransaction>> SearchPaymentTransactionAsync(
            Guid? storeId = null,
            PaymentStatus? paymentStatus = PaymentStatus.ACCEPTED,
            Guid? paymentLinkId = null, 
            Guid? productId = null, 
            int page = 1, int pageSize = 10)
        {
            var query = _dbContext.PaymentTransaction
                .Include(p => p.PaymentLink)
                .OrderByDescending(p => p.Created).AsQueryable();
            if (storeId.HasValue)
                query = query.Where(p => p.PaymentLink.StoreId == storeId);

            if (paymentStatus.HasValue)
                query = query.Where(p => p.PaymentStatus == paymentStatus);
            if (paymentLinkId.HasValue)
                query = query.Where(p => p.PaymentLinkId == paymentLinkId);
            if (productId.HasValue)
                query = query.Where(p => p.PaymentLink.ProductId == productId);


            return new PagedResult<PaymentTransaction>
            {
                Total = await query.CountAsync(),
                Items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync()
            };
        }

        public async Task<IList<PaymentLink>> GetPaymentLinksAsync(Guid storeId, IEnumerable<Guid> paymentLinkIds)
        {
            return await _dbContext.PaymentLink.AsNoTracking()
                .Where(p => p.StoreId == storeId && paymentLinkIds.Contains(p.Id)).ToListAsync();
        }

        public async Task<PaymentLink> UpdatePaymentLinkAsync(PaymentLink paymentLink)
        {
            _dbContext.PaymentLink.Attach(paymentLink);
            _dbContext.Entry(paymentLink).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            _dbContext.Entry(paymentLink).State = EntityState.Detached;
            return await GetPaymentLinkAsync(paymentLink.PaymentLinkRef);
        }
    }
}
