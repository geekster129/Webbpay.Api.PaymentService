using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;
using MediatR;

namespace Webbpay.Api.PaymentService.Models.Commands
{
    public class CreatePaymentTransactionCommand : IRequest<Unit>
    {
        public CreatePaymentTransactionModel TransactionModel { get; set; }

        public CreatePaymentTransactionCommand(CreatePaymentTransactionModel transactionModel)
        {
            TransactionModel = transactionModel;
        }
    }
}
