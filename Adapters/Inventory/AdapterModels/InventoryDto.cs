using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Adapters.Inventory.AdapterModels
{
  [Serializable]
  public class InventoryDto
  {
    [JsonProperty("storeId")]
    public Guid StoreId { get; set; }
    [JsonProperty("itemImages")]
    public virtual List<ItemImageDto> ItemImages { get; set; }
    [JsonProperty("quantity")]
    public int Quantity { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("sku")]
    public string SKU { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
  }
}
