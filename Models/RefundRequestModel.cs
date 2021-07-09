using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Models
{
    public class RefundRequestModel
    {
        [Required]
        public Guid StoreId { get; set; }
        [Required]
        public Guid PaymentTransactionId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        [Required]
        public string IpAddress { get; set; }
        [Required]
        public string UserAgent { get; set; }
    }
}
