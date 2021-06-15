using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Models
{
    public class CreatePaymentTransactionModel
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public PaymentMode PaymentMode { get; set; }

        [Required]
        public Guid PaymentChannelId { get; set; }

        [Required]
        public Guid PaymentLinkId { get; set; }

        [Required]
        public string PaymentOrderNo { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Phone]
        public string ContactMobileNo { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPostcode { get; set; }        
        public string ContactState { get; set; }
        [MaxLength(3)]
        public string ContactCountry { get; set; } = "MY";
    }
}
