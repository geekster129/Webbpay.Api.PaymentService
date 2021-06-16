using System;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Models
{
    public class PatchPaymentTransactionModel
    {
        public Guid PaymentTransactionId { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public string PaymentRef1 { get; set; }

        public string PaymentRef2 { get; set; }

        public string PaymentRef3 { get; set; }
    }
}
