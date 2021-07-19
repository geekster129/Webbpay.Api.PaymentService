using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Models.Dtos
{
    public class PaymentLinkDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public string PaymentLinkRef { get; set; }
        public string PaymentLinkDesc { get; set; }
        public int SuccessfulTransactions { get; set; }
        public PaymentLinkStatus Status { get; set; } = PaymentLinkStatus.Active;
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ExpiryDate { get; set; }
  }
}
