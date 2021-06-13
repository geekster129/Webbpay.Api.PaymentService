using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Entities
{
    public class PagedResult<T>
    {
        public int Total { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
