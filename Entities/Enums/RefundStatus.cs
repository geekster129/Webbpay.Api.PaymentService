using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Entities.Enums
{
    public enum RefundStatus
    {
        Pending,
        Success,
        Failed,
        Cancelled
    }
}
