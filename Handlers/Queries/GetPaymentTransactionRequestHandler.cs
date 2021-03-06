using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Entities;
using System.Threading;
using Webbpay.Api.PaymentService.Repositories;
using AutoMapper;
using Webbpay.Api.PaymentService.Mappers;
using Webbpay.Api.PaymentService.Models.Queries;

namespace Webbpay.Api.PaymentService.Handlers.Queries
{
    public class GetPaymentTransactionRequestHandler : IRequestHandler<GetPaymentTransactionRequestModel, List<PaymentTransactionDto>>
    {
        private readonly IPaymentRepository _repository;

        public GetPaymentTransactionRequestHandler(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PaymentTransactionDto>> Handle(GetPaymentTransactionRequestModel request, CancellationToken cancellationToken)
        {
            var paymentTransaction = await _repository.GetPaymentTransactionsAsync(request.PaymentLinkRef);
            return paymentTransaction
                    .Select(t => t.ToModel())
                    .ToList();
        }
    }
}
