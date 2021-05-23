using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;
using MediatR;

namespace Webbpay.Api.PaymentService.Models
{
    public class CheckPaymentLinkParamsValidRequestModel : IRequest<ValidationResponseDto>
    {        
        public Guid StoreId { get; set; }
        public Guid InventoryId { get; set; }
        public string PaymentLinkRef { get; set; }

        public CheckPaymentLinkParamsValidRequestModel(Guid storeId, Guid inventoryId, string paymentLinkRef)
        {
          StoreId = storeId;
          InventoryId = inventoryId;
          PaymentLinkRef = paymentLinkRef;
        }
    }
}
