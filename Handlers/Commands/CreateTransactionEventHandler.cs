using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Mappers;
using Webbpay.Api.PaymentService.Models.Commands;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models.Notifications;
using Webbpay.Api.PaymentService.Repositories;

namespace Webbpay.Api.PaymentService.Handlers.Commands
{
    public class CreateTransactionEventHandler : IRequestHandler<CreateTransactionEventCommand, TransactionEventDto>
    {
        private readonly ITransactionEventRepository _transactionEventRepository;
        private readonly IMediator _mediator;

        public CreateTransactionEventHandler(ITransactionEventRepository transactionEventRepository, IMediator mediator)
        {
            _transactionEventRepository = transactionEventRepository;
            _mediator = mediator;
        }

        public async Task<TransactionEventDto> Handle(CreateTransactionEventCommand request, CancellationToken cancellationToken)
        {
            var @event = request.Event.ToEntity();
            @event = await _transactionEventRepository.Create(@event);

            var result = @event.ToModel();
            await _mediator.Publish(new TransactionEventCreatedNotification(result));
            return result;
        }
    }
}
