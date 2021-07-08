using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentMode
    {
        EWALLET, VISA, MASTER, FPX, FPXB2B
    }
}
