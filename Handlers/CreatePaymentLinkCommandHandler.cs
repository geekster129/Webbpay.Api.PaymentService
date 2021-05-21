using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models;
using System.Threading;

namespace Webbpay.Api.PaymentService.Handlers
{
  public class CreatePaymentLinkCommandHandler : IRequestHandler<CreatePaymentLinkRequestModel>
  {
    public Task<Unit> Handle(CreatePaymentLinkRequestModel request, CancellationToken cancellationToken)
    {
      return Task.FromResult(Unit.Value);
    }
  }
}
