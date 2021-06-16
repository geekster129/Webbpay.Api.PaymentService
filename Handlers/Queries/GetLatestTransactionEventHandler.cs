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
    public class GetLatestTransactionEventHandler : IRequestHandler<GetLatestTransactionEventQuery, TransactionEventDto>
    {
        private readonly ITransactionEventRepository _transactionEventRepository;

        public GetLatestTransactionEventHandler(ITransactionEventRepository transactionEventRepository)
        {
            _transactionEventRepository = transactionEventRepository;
        }

        public async Task<TransactionEventDto> Handle(GetLatestTransactionEventQuery request, CancellationToken cancellationToken)
        {
            var @event = await _transactionEventRepository.GetLatestEvent(request.PaymentTransactionId);
            return @event.ToModel();
        }
    }
}
