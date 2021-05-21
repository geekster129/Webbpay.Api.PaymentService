using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Entities;
using System.Threading;

namespace Webbpay.Api.PaymentService.Handlers
{
  public class GetPaymentLinkRequestHandler : IRequestHandler<GetPaymentLinkRequestModel, PaymentLink>
  {
    public Task<PaymentLink> Handle(GetPaymentLinkRequestModel request, CancellationToken cancellationToken)
    {
      return Task.FromResult(new PaymentLink());
    }
  }
}
