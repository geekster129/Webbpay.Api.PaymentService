using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Models
{
    public class CreateTransactionEventModel
    {
        [Required]
        public Guid PaymentTransactionId { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        public string EventData { get; set; }
    }
}
