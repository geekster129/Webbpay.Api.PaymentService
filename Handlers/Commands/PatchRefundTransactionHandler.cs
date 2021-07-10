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
    public class PatchRefundTransactionHandler : IRequestHandler<PatchRefundTransactionCommand, RefundTransactionDto>
    {
        private readonly IRefundRepository _refundRepository;

        public PatchRefundTransactionHandler(IRefundRepository refundRepository)
        {
            _refundRepository = refundRepository;
        }

        public async Task<RefundTransactionDto> Handle(PatchRefundTransactionCommand request, CancellationToken cancellationToken)
        {
            var refundTransaction = await _refundRepository.Get(request.PatchModel.RefundTransactionId);
            if(refundTransaction == null)
                throw new Exception("Invalid refund transaction");
            refundTransaction = refundTransaction.PatchEntity(request.PatchModel);

            refundTransaction = await _refundRepository.Update(refundTransaction);

            return refundTransaction.ToModel();
        }
    }
}
