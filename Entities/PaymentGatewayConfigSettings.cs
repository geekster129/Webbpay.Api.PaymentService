using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webbpay.Api.PaymentService.Entities
{
    public class PaymentGatewayConfigSettings
    {
        [Key]
        public Guid Id { get; set; }
    }
}
