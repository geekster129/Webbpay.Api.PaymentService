using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;
using MediatR;

namespace Webbpay.Api.PaymentService.Models
{
    public class CheckStoreIdInventoryIdExistsRequestModel : IRequest<ValidationResponseDto>
    {        
        public Guid StoreId { get; set; }

        public Guid InventoryId { get; set; }

        public CheckStoreIdInventoryIdExistsRequestModel(Guid storeId, Guid inventoryId)
        {
          StoreId = storeId;
          InventoryId = inventoryId;
        }
    }
}
