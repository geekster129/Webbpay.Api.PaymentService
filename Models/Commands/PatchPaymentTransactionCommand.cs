using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Commands
{
    public class PatchPaymentTransactionCommand : IRequest<PaymentTransactionDto>
    {
        public PatchPaymentTransactionCommand(
            PatchPaymentTransactionModel patchModel
            )
        {
            PatchModel = patchModel;
        }

        public PatchPaymentTransactionModel PatchModel { get; }
    }
}
