using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Adapters.Store
{
  public class StoreAdapter : IStoreAdapter
  {
    private IHttpClientFactory _httpClientFactory;

    public StoreAdapter(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task GetStore(Guid storeId)
    {
      try
      {
        var client = _httpClientFactory.CreateClient("Store");
        await client.GetAsync($"/api/store{storeId}");
      }
      catch (Exception ex) { }
    }
  }
}
