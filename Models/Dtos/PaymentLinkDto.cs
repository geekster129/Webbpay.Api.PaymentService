using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;

namespace Webbpay.Api.PaymentService.Models.Dtos
{
    public class PaymentLinkDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public string PaymentLinkRef { get; set; }
        public PaymentLinkStatus Status { get; set; } = PaymentLinkStatus.Active;
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpiryDate { get; set; }
  }
}
