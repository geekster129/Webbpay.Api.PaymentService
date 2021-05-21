using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models
{
    public class CreatePaymentLinkRequestModel
    {        
        public PaymentLinkDto PaymentLinkDto { get; set; }

        public CreatePaymentLinkRequestModel(PaymentLinkDto paymentLinkDto)
        {
          PaymentLinkDto = paymentLinkDto;
        }
    }
}
