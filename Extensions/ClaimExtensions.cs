using IdentityModel;
using System.Linq;
using System.Security.Claims;

namespace Webbpay.Api.PaymentService.Extensions
{
    public static class ClaimExtensions
    {
        public static string GetEmail(this ClaimsPrincipal principal)
        {
            return principal?.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Email)?.Value;
        }

        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal?.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject)?.Value;
        }
    }
}
