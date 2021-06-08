using System;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Adapters.Inventory.AdapterModels;

namespace Webbpay.Api.PaymentService.Adapters.Inventory
{
    public interface IInventoryAdapter
    {
        Task<InventoryDto> GetInventory(Guid inventoryId);

        Task<ProductDto> GetProduct(Guid storeId, Guid productId);
    }
}