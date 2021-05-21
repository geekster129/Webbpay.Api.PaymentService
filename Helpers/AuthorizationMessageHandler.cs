using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace Webbpay.Api.PaymentService.Helpers
{
  public class AuthorizationMessageHandler : DelegatingHandler
  {
    private readonly IHttpContextAccessor _context;

    public AuthorizationMessageHandler(IHttpContextAccessor context)
    {
      _context = context;
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      var authHeader = _context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();      
      AuthenticationHeaderValue.TryParse(authHeader, out var header);
      request.Headers.Authorization = header;
      return base.SendAsync(request, cancellationToken);
    }
  }
}
