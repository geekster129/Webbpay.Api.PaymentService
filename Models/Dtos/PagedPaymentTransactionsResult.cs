using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Models.Dtos
{
    public class PagedPaymentTransactionsResult
    {
        public int Total { get; set; }

        public IEnumerable<PaymentTransactionDto> Items { get; set; }
    }
}
