using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Commands
{
    public class PatchRefundTransactionCommand : IRequest<RefundTransactionDto>
    {
        public PatchRefundTransactionCommand(PatchRefundTransactionModel patchModel)
        {
            PatchModel = patchModel;
        }

        public PatchRefundTransactionModel PatchModel { get; }
    }
}
