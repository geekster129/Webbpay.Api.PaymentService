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

namespace Webbpay.Api.PaymentService.Handlers.Commands
{
    public class CreatePaymentTransactionRequestHandler : IRequestHandler<CreatePaymentTransactionCommand>
    {
        private readonly IPaymentRepository _repository;
        private readonly ITransactionEventRepository _transactionEventRepository;
        private readonly IHttpContextAccessor _httpContext;

        public CreatePaymentTransactionRequestHandler(
            IPaymentRepository repository,
            IHttpContextAccessor httpContext,
            ITransactionEventRepository transactionEventRepository)
        {
            _repository = repository;
            _httpContext = httpContext;
            _transactionEventRepository = transactionEventRepository;
        }

        public async Task<Unit> Handle(CreatePaymentTransactionCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContext.HttpContext.User.GetUserId();

            var paymentTransaction = request.TransactionModel.ToEntity();
            paymentTransaction.CreatedBy = userId;

            await _repository.CreatePaymentTransactionAsync(paymentTransaction);

            var @event = new TransactionEvent
            {
                CreatedBy = userId,
                EventData = JsonSerializer.Serialize(request.TransactionModel),
                PaymentStatus = paymentTransaction.PaymentStatus,
                PaymentTransactionId = paymentTransaction.Id
            };

            await _transactionEventRepository.Create(@event);

            return Unit.Value;
        }
    }
}
