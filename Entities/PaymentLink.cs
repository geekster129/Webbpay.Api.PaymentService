using System;
using System.ComponentModel.DataAnnotations;

namespace Webbpay.Api.PaymentService.Entities
{
    public class PaymentLink
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid StoreId { get; set; }
        public string? PaymentLinkRef { get; set; }
        public Guid InventoryId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;
        public Guid UpdatedBy { get; set; }

        public virtual PaymentTransaction PaymentTransaction { get; set; }
  }
}
