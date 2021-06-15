using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;

namespace Webbpay.Api.PaymentService.Adapters.Database
{
    public class PaymentDbContext : DbContext
    {
        public DbSet<PaymentLink> PaymentLink { get; set; }
        public DbSet<PaymentTransaction> PaymentTransaction { get; set; }

        public DbSet<TransactionEvent> TransactionEvents { get; set; }

        public PaymentDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PaymentLink>().HasKey(pl => new { pl.Id, pl.StoreId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
