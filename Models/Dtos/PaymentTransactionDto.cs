using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Models.Dtos
{
    public class PaymentTransactionDto
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public Guid PaymentChannelId { get; set; }

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.PENDING;
        public PaymentMode PaymentMode { get; set; } 

        [Required]
        public Guid PaymentLinkId { get; set; }

        public string PaymentChannel { get; set; }

        public string PaymentOrderNo { get; set; }
        public string PaymentRemarks { get; set; }
        public string ContactName { get; set; }
        public string ContactMobileNo { get; set; }
        public string ContactEmail { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPostcode { get; set; }
        public string ContactState { get; set; }
        public string ContactCountry { get; set; } = "MY";
        
        public PaymentLinkDto PaymentLink { get; set; }
        
  }
}
