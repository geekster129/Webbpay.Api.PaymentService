using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;

namespace Webbpay.Api.PaymentService.Models.Dtos
{
    public class PaymentTransactionDto
    {
        [Key]
        public Guid Id { get; set; }
        public string PaymentLinkRef { get; set; }
        public PaymentMode PaymentMode { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string PaymentRefNo { get; set; }
        public string PaymentRemarks { get; set; }
        public string ContactName { get; set; }
        public string ContactMobileNo { get; set; }
        public string ContactEmail { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPostcode { get; set; }
        public string ContactState { get; set; }
  }
}
