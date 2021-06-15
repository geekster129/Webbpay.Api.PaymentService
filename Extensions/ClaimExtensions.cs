using IdentityModel;
using System.Linq;
using System.Security.Claims;

namespace Webbpay.Api.PaymentService.Extensions
{
    public static class ClaimExtensions
    {
        public static string GetEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(JwtClaimTypes.Email);
        }

        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(JwtClaimTypes.Subject) ?? 
                principal.FindFirstValue(JwtClaimTypes.ClientId);            
        }
    }
}
