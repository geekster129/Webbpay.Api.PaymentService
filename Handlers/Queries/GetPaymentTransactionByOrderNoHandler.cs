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
    public class GetPaymentTransactionByOrderNoHandler :
        IRequestHandler<GetPaymentTransactionByOrderNoQuery, PaymentTransactionDto>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentTransactionByOrderNoHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentTransactionDto> Handle(GetPaymentTransactionByOrderNoQuery request, CancellationToken cancellationToken)
        {
            var result = await _paymentRepository.GetPaymentTransactionByOrderNo(request.OrderNo);
            return result.ToModel();
        }
    }
}
