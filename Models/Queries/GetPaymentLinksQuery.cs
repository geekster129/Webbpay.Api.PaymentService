using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Queries
{
    public class GetPaymentLinksQuery : IRequest<IList<PaymentLinkDto>>
    {
        public GetPaymentLinksQuery(
            Guid storeId,
            IEnumerable<Guid> paymentLinkIds
            )
        {
            StoreId = storeId;
            PaymentLinkIds = paymentLinkIds;
        }

        public Guid StoreId { get; }
        public IEnumerable<Guid> PaymentLinkIds { get; }
    }
}
