using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Models.Queries
{
    public class GetPaymentLinkStatusQuery : IRequest<PaymentLinkStatus>
    {
        public GetPaymentLinkStatusQuery(string paymentlinkRef)
        {
            PaymentlinkRef = paymentlinkRef;
        }

        public string PaymentlinkRef { get; }
    }
}
