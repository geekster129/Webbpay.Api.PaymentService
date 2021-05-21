using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Entities
{
    public class PaymentGatewayConfigValue
    {
        [Key]
        public Guid Id { get; set; }
        public string ConfigType { get; set; }
        public string ConfigValue { get; set; }
    }
}
