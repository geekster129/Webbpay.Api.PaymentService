using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Adapters.UserProfile
{
  public class UserProfileAdapter : IUserProfileAdapter
  {
    private IHttpClientFactory _httpClientFactory;

    public UserProfileAdapter(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task AddUserStore(Guid storeId)
    {
      try
      {
        var client = _httpClientFactory.CreateClient("UserProfile");
        await client.PostAsync($"/api/user/store/link?storeId={storeId}", new StringContent("", UnicodeEncoding.UTF8, "application/text"));
      }
      catch (Exception ex) { }
    }
  }
}
