using System;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Adapters.UserProfile
{
  public interface IUserProfileAdapter
  {
    Task AddUserStore(Guid storeId);
  }
}