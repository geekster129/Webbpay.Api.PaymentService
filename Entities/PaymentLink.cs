using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Entities
{
    [Index(nameof(Status))]
    [Index(nameof(Id), nameof(StoreId), IsUnique = true)]
    [Index(nameof(ProductId))]
    public class PaymentLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public string? PaymentLinkRef { get; set; }
        public int SuccessfulTransactions { get; set; }
        public Guid ProductId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        [Column(TypeName = "varchar(15)")]
        public PaymentLinkStatus Status { get; set; } = PaymentLinkStatus.Active;

        public DateTime Created { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; }

        public virtual List<PaymentTransaction> PaymentTransactions { get; set; }

    }
}
