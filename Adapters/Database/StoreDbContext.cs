using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;

namespace Webbpay.Api.PaymentService.Adapters.Database
{
    public class StoreDbContext : DbContext
  {
    public DbSet<PaymentLink> PaymentLink { get; set; }
    public DbSet<PaymentTransaction> PaymentTransaction { get; set; }
    public DbSet<PaymentGatewayConfig> PaymentGatewayConfig { get; set; }
    public DbSet<PaymentGatewayConfigSettings> PaymentGatewayConfigSettings { get; set; }
    public DbSet<PaymentGatewayConfigValue> PaymentGatewayConfigValue { get; set; }

    public StoreDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
