using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Mappers;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models.Queries;
using Webbpay.Api.PaymentService.Repositories;

namespace Webbpay.Api.PaymentService.Handlers.Queries
{
    public class SearchRefundTransactionHandler : IRequestHandler<SearchRefundTransactionQuery, PagedRefundTransactionResult>
    {
        private readonly IRefundRepository _refundRepository;

        public SearchRefundTransactionHandler(IRefundRepository refundRepository)
        {
            _refundRepository = refundRepository;
        }

        public async Task<PagedRefundTransactionResult> Handle(SearchRefundTransactionQuery request, CancellationToken cancellationToken)
        {
            var result = await _refundRepository.SearchAll(request.Status, request.Page, request.PageSize);

            return result.ToModel();
        }
    }
}
