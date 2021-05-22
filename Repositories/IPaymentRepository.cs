using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;

namespace Webbpay.Api.PaymentService.Repositories
{
  public interface IPaymentRepository
  {
    Task CreatePaymentLinkAsync(PaymentLink paymentLink);
    Task<PaymentLink> GetPaymentLinkAsync(string paymentLinkRef);
  }
}