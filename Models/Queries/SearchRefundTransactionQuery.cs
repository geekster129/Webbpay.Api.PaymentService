using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Queries
{
    public class SearchRefundTransactionQuery : IRequest<PagedRefundTransactionResult>
    {
        public SearchRefundTransactionQuery(
            RefundStatus status,
            int page = 1,
            int pageSize = 10)
        {
            Status = status;
            Page = page;
            PageSize = pageSize;
        }

        public RefundStatus Status { get; }
        public int Page { get; }
        public int PageSize { get; }
    }
}
