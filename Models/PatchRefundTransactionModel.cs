using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Models
{
    public class PatchRefundTransactionModel
    {
        public Guid RefundTransactionId { get; set; }

        public RefundStatus RefundStatus { get; set; }

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; }
    }
}
