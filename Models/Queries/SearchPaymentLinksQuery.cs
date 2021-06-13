using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Queries
{
    public class SearchPaymentLinksQuery : IRequest<PagedPaymentLinkResult>
    {
        public SearchPaymentLinksQuery(
            PaymentLinkStatus status = PaymentLinkStatus.Active,
            int page = 1,
            int pageSize = 10
            )
        {
            Status = status;
            Page = page;
            PageSize = pageSize;
        }

        public PaymentLinkStatus Status { get; }
        public int Page { get; }
        public int PageSize { get; }
    }
}
