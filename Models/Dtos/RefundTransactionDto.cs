using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Models.Dtos
{
    public class RefundTransactionDto
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }
   
        public string Reason { get; set; }

        public RefundStatus RefundStatus { get; set; }

        public Guid PaymentTransactionId { get; set; }
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string UpdatedBy { get; set; } = null;

        public DateTime? Updated { get; set; } = null;

    }
}
