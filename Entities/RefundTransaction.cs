using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Entities
{
    [Index(nameof(Created))]
    [Index(nameof(RefundStatus))]
    public class RefundTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        [StringLength(255)]
        public string Reason { get; set; }

        [Column(TypeName = "varchar(10)")]
        public RefundStatus RefundStatus { get; set; }

        [StringLength(50)]
        public string ExternalRefNo { get; set; }

        public Guid PaymentTransactionId { get; set; }

        [MaxLength(100)]
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string UpdatedBy { get; set; } = null;

        public DateTime? Updated { get; set; } = null;

        [ForeignKey(nameof(PaymentTransactionId))]
        public virtual PaymentTransaction PaymentTransaction { get; set; }

        public virtual ICollection<RefundEvent> Events { get; set; }
    }
}
