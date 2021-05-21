using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Entities
{
    public class PaymentGatewayConfig
    {
        [Key]
        public Guid Id { get; set; }
        public virtual List<PaymentGatewayConfigValue> PaymentGatewayValues { get; set; }
        public GatewayType GatewayType { get; set; }
    }

    public enum GatewayType
    {
        Type1, Type2
    }
}
