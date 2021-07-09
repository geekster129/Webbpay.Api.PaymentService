using System.Net.Http;

namespace Webbpay.Api.PaymentService.Repositories
{
    public class RazerRepository : IRazerRepository
    {
        private HttpClient _httpClient;

        public RazerRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
