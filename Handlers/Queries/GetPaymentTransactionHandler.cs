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
    public class GetPaymentTransactionHandler : IRequestHandler<GetPaymentTransactionQuery, PaymentTransactionDto>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentTransactionHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentTransactionDto> Handle(GetPaymentTransactionQuery request, CancellationToken cancellationToken)
        {
            var result = await _paymentRepository.GetPaymentTransactionById(request.TransactionId);
            return result.ToModel();
        }
    }
}
