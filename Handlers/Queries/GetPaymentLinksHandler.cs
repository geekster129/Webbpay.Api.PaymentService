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
    public class GetPaymentLinksHandler : IRequestHandler<GetPaymentLinksQuery, IList<PaymentLinkDto>>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentLinksHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IList<PaymentLinkDto>> Handle(GetPaymentLinksQuery request, CancellationToken cancellationToken)
        {
            var result = await _paymentRepository.GetPaymentLinksAsync(request.StoreId, request.PaymentLinkIds);
            return result.ToModel();
        }
    }
}
