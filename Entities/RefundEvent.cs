using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Entities
{
    public class RefundEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid RefundTransactionId { get; set; }

        [Column(TypeName = "varchar(10)")]
        public RefundStatus RefundStatus { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Any data to just pump in
        /// </summary>
        public string EventData { get; set; }

        #region Audit fields 
        [MaxLength(30)]
        public string IpAddress { get; set; }
        [MaxLength(255)]
        public string UserAgent { get; set; }
        #endregion

        [ForeignKey(nameof(RefundTransactionId))]
        public virtual RefundTransaction RefundTransaction { get; set; }
    }
}
