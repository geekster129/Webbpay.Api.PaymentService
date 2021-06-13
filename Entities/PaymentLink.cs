using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Webbpay.Api.PaymentService.Entities
{
    [Index("Status")]
    public class PaymentLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public string? PaymentLinkRef { get; set; }
        public Guid ProductId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

        [Column(TypeName = "varchar(15)")]
        public PaymentLinkStatus Status { get; set; } = PaymentLinkStatus.Active;

        public DateTime Created { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;
        public Guid UpdatedBy { get; set; }

        public virtual List<PaymentTransaction> PaymentTransactions { get; set; }

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentLinkStatus
    {
        Active,
        Inactive,
        Expired,
        QuoteMaxed,
        Deleted
    }
}
