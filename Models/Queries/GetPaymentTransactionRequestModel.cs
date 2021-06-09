using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Entities;
using MediatR;

namespace Webbpay.Api.PaymentService.Models.Queries
{
    public class GetPaymentTransactionRequestModel : IRequest<List<PaymentTransactionDto>>
    {
        public string PaymentLinkRef { get; set; }

        public GetPaymentTransactionRequestModel(string paymentLinkRef)
        {
            PaymentLinkRef = paymentLinkRef;
        }
    }
}
