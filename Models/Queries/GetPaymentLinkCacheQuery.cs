using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Models.Queries
{
    public class GetPaymentLinkCacheQuery : IRequest<string>
    {
        public GetPaymentLinkCacheQuery(string paymentLinkRef)
        {
            PaymentLinkRef = paymentLinkRef;
        }

        public string PaymentLinkRef { get; }
    }
}
