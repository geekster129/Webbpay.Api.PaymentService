using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Models.Dtos
{
    public class PaymentLinkDto
    {
        public Guid StoreId { get; set; }
        public Guid InventoryId { get; set; }
        public string PaymentLinkRef { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
