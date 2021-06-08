using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Adapters.Inventory.AdapterModels;

namespace Webbpay.Api.PaymentService.Adapters.Inventory
{
    public class InventoryAdapter : IInventoryAdapter
    {
        private IHttpClientFactory _httpClientFactory;

        public InventoryAdapter(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<InventoryDto> GetInventory(Guid inventoryId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Inventory");
                var response = await client.GetAsync($"api/Inventories/inventory/{inventoryId}");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<InventoryDto>(responseBody);
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<ProductDto> GetProduct(Guid storeId, Guid productId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Inventory");
                var response = await client.GetAsync($"api/store/{storeId}/products/{productId}");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ProductDto>(responseBody);
                }
            }
            catch (Exception ex) { }

            return null;
        }
    }
}
