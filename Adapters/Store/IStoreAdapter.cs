using System;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Adapters.Store
{
  public interface IStoreAdapter
  {
    Task GetStore(Guid storeId);
  }
}