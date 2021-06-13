using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Models.Dtos
{
    public class PagedPaymentLinkResult
    {
        public int Total { get; set; }

        public IEnumerable<PaymentLinkDto> Items { get; set; }
    }
}
