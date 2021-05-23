using System;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Adapters.Store.AdapterModels;

namespace Webbpay.Api.PaymentService.Adapters.Store
{
  public interface IStoreAdapter
  {
    Task<StoreDto> GetStore(Guid storeId);
  }
}