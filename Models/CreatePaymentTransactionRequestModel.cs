using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;
using MediatR;

namespace Webbpay.Api.PaymentService.Models
{
    public class CreatePaymentTransactionRequestModel : IRequest<Unit>
    {        
        public PaymentTransactionDto PaymentTransactionDto { get; set; }

        public string UserId { get; set; }

        public CreatePaymentTransactionRequestModel(string userId, PaymentTransactionDto paymentTransactionDto)
        {
          PaymentTransactionDto = paymentTransactionDto;
          UserId = userId;
        }
    }
}
