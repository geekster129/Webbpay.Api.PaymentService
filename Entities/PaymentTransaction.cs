using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webbpay.Api.PaymentService.Entities
{
    [Index(nameof(PaymentOrderNo), IsUnique = true)]
    public class PaymentTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public decimal Amount { get; set; }

        [Column(TypeName = "varchar(10)")]
        public PaymentStatus PaymentStatus { get; set; }

        [Column(TypeName = "varchar(10)")]
        public PaymentMode PaymentMode { get; internal set; }

        public Guid PaymentLinkId { get; set; }

        /// <summary>
        /// Set by payment gateway, Razer
        /// </summary>
        [MaxLength(50)]
        public string PaymentChannel { get; set; }

        /// <summary>
        /// Called order id for payment gateway
        /// </summary>
        [MaxLength(50)]
        public string PaymentOrderNo { get; set; }


        public string PaymentRemarks { get; set; }

        [MaxLength(100)]
        public string ContactName { get; set; }
        
        [MaxLength(50)]
        public string ContactMobileNo { get; set; }
        
        [MaxLength(100)]
        public string ContactEmail { get; set; }
        
        [MaxLength(100)]
        public string ContactAddress { get; set; }
        
        [MaxLength(10)]
        public string ContactPostcode { get; set; }
        
        [MaxLength(25)]
        public string ContactState { get; set; }

        [MaxLength(3)]
        public string ContactCountry { get; set; } = "MY";

        [MaxLength(100)]
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        
        public string PaymentRef1 { get; set; }

        public string PaymentRef2 { get; set; }

        public Guid PaymentChannelId { get; set; }

        public string PaymentRef3 { get; set; }

        [ForeignKey(nameof(PaymentLinkId))]
        public virtual PaymentLink PaymentLink { get; set; }

        public virtual ICollection<TransactionEvent> Events { get; set; }
    }


}

