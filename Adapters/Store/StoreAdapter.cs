using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Webbpay.Api.PaymentService.Adapters.Store.AdapterModels;

namespace Webbpay.Api.PaymentService.Adapters.Store
{
  public class StoreAdapter : IStoreAdapter
  {
    private IHttpClientFactory _httpClientFactory;

    public StoreAdapter(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<StoreDto> GetStore(Guid storeId)
    {
      try
      {
        var client = _httpClientFactory.CreateClient("Store");
        var response = await client.GetAsync($"/api/Store/store-details/{storeId}");
        if(response.IsSuccessStatusCode)
        {
          string responseBody = await response.Content.ReadAsStringAsync();
          return JsonConvert.DeserializeObject<StoreDto>(responseBody);
        }
      }
      catch (Exception ex) { }

      return null;
    }

  }
}
