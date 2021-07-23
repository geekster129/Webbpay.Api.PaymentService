using MediatR;
using System;
using Webbpay.Api.PaymentService.Entities.Enums;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Queries
{
    public class SearchPaymentLinksQuery : IRequest<PagedPaymentLinkResult>
    {
        public SearchPaymentLinksQuery(
            Guid? storeId,
            PaymentLinkStatus status = PaymentLinkStatus.Active,
            Guid? productId = null,
            int page = 1,
            int pageSize = 10,
            bool forceCheckExpired = false
            )
        {
            StoreId = storeId;
            Status = status;
            ProductId = productId;
            Page = page;
            PageSize = pageSize;
            ForceCheckExpired = forceCheckExpired;
        }

        public Guid? StoreId { get; }
        public PaymentLinkStatus Status { get; }
        public Guid? ProductId { get; }
        public int Page { get; }
        public int PageSize { get; }
        public bool ForceCheckExpired { get; set; }
    }
}
