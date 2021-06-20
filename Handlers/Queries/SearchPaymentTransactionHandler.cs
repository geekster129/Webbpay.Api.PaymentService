using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Mappers;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models.Queries;
using Webbpay.Api.PaymentService.Repositories;

namespace Webbpay.Api.PaymentService.Handlers.Queries
{
    public class SearchPaymentTransactionHandler : IRequestHandler<SearchPaymentTransactionQuery, PagedPaymentTransactionsResult>
    {
        private readonly IPaymentRepository _paymentRepository;

        public SearchPaymentTransactionHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PagedPaymentTransactionsResult> Handle(SearchPaymentTransactionQuery request, CancellationToken cancellationToken)
        {
            var result = await _paymentRepository.SearchPaymentTransactionAsync(
                request.StoreId,
                request.PaymentStatus,
                request.PaymentLinkId,
                request.ProductId,
                request.Page,
                request.PageSize
                );
            return result.ToModel();
        }
    }
}
