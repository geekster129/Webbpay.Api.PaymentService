using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Adapters.Inventory.AdapterModels
{
  [Serializable]
  public class ItemImageDto
  {
    [JsonProperty("sequence")]
    public int Sequence { get; set; }
    [JsonProperty("url")]
    public string URL { get; set; }
    [JsonProperty("minifiedURL")]
    public string MinifiedURL { get; set; }
  }
}
