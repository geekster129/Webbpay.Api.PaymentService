using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Adapters.Store.AdapterModels
{
  [Serializable]
  public class StoreDto
  {
    [JsonProperty("id")]
    public Guid Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("active")]
    public bool Active { get; set; }
  }

}
