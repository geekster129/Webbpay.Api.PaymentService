﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Models
{
    public class CreateRefundEventModel
    {
        [Required]
        public Guid RefundTransactionId { get; set; }

        [Required]
        public RefundStatus RefundStatus { get; set; }

        public string EventData { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }
    }
}
