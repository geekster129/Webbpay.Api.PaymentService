using System.Threading.Tasks;
using MediatR;
using Webbpay.Api.PaymentService.Extensions;
using System.Threading;
using Webbpay.Api.PaymentService.Repositories;
using Webbpay.Api.PaymentService.Entities;
using Microsoft.AspNetCore.Http;
using Webbpay.Api.PaymentService.Mappers;
using Webbpay.Api.PaymentService.Models.Commands;
using System.Text.Json;
using Webbpay.Api.PaymentService.Models.Notifications;

namespace Webbpay.Api.PaymentService.Handlers.Commands
{
    public class CreatePaymentTransactionRequestHandler : IRequestHandler<CreatePaymentTransactionCommand>
    {
        private readonly IPaymentRepository _repository;
        private readonly ITransactionEventRepository _transactionEventRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMediator _mediator;

        public CreatePaymentTransactionRequestHandler(
            IPaymentRepository repository,
            IHttpContextAccessor httpContext,
            ITransactionEventRepository transactionEventRepository, IMediator mediator)
        {
            _repository = repository;
            _httpContext = httpContext;
            _transactionEventRepository = transactionEventRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreatePaymentTransactionCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContext.HttpContext.User.GetUserId();

            var paymentTransaction = request.TransactionModel.ToEntity();
            paymentTransaction.CreatedBy = userId;

            paymentTransaction = await _repository.CreatePaymentTransactionAsync(paymentTransaction);

            var @event = new TransactionEvent
            {
                CreatedBy = userId,
                EventData = JsonSerializer.Serialize(request.TransactionModel),
                PaymentStatus = paymentTransaction.PaymentStatus,
                PaymentTransactionId = paymentTransaction.Id,
                IpAddress = request.TransactionModel.IpAddress,
                UserAgent = request.TransactionModel.UserAgent
            };

            await _transactionEventRepository.Create(@event);

            await _mediator.Publish(new TransactionCreatedEvent(paymentTransaction.ToModel()));
                        
            return Unit.Value;
        }
    }
}
