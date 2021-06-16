using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Mappers;
using Webbpay.Api.PaymentService.Models.Commands;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Repositories;

namespace Webbpay.Api.PaymentService.Handlers.Commands
{
    public class PatchPaymentTransactionHandler : IRequestHandler<PatchPaymentTransactionCommand, PaymentTransactionDto>
    {
        private readonly IPaymentRepository _paymentRepository;

        public PatchPaymentTransactionHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentTransactionDto> Handle(PatchPaymentTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _paymentRepository.GetPaymentTransactionById(request.PatchModel.PaymentTransactionId);
            if (transaction == null)
                throw new Exception("Invalid payment transaction");

            transaction = transaction.PatchEntity(request.PatchModel);

            await _paymentRepository.UpdatePaymentTransactionAsync(transaction);

            return transaction.ToModel();
        }
    }
}
