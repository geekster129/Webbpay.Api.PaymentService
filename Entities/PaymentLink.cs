using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webbpay.Api.PaymentService.Entities
{
    public class PaymentLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
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

        public virtual List<PaymentTransaction> PaymentTransactions { get; set; }

  }
}
