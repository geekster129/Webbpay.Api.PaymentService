﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentLinkStatus
    {
        Active,
        Inactive,
        Expired,
        QuoteMaxed,
        Deleted
    }
}
