using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Queries
{
    public class SearchPaymentTransactionQuery : IRequest<PagedPaymentTransactionsResult>
    {
        public SearchPaymentTransactionQuery(
            Guid storeId,
            PaymentStatus? paymentStatus = null,
            Guid? paymentLinkId = null,
            Guid? productId = null,
            int page = 1,
            int pageSize = 10)
        {
            StoreId = storeId;
            PaymentStatus = paymentStatus;
            PaymentLinkId = paymentLinkId;
            ProductId = productId;
            Page = page;
            PageSize = pageSize;
        }

        public Guid StoreId { get; }
        public PaymentStatus? PaymentStatus { get; }
        public Guid? PaymentLinkId { get; }
        public Guid? ProductId { get; }
        public int Page { get; }
        public int PageSize { get; }
    }
}
