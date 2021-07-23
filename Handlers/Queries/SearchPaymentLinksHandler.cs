using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models.Queries;
using Webbpay.Api.PaymentService.Repositories;
using Webbpay.Api.PaymentService.Mappers;

namespace Webbpay.Api.PaymentService.Handlers.Queries
{
    public class SearchPaymentLinksHandler : IRequestHandler<SearchPaymentLinksQuery, PagedPaymentLinkResult>
    {
        private readonly IPaymentRepository _paymentRepository;

        public SearchPaymentLinksHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PagedPaymentLinkResult> Handle(SearchPaymentLinksQuery request, CancellationToken cancellationToken)
        {
            var result = await _paymentRepository.SearchPaymentLinkAsync(
                request.StoreId,
                request.Status,
                request.ProductId,
                request.Page,
                request.PageSize,
                request.ForceCheckExpired
                );

            return result.ToModel();
        }
    }
}
