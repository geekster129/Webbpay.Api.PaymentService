using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Entities;
using System.Threading;
using Webbpay.Api.PaymentService.Repositories;

namespace Webbpay.Api.PaymentService.Handlers
{
  public class GetPaymentLinkRequestHandler : IRequestHandler<GetPaymentLinkRequestModel, PaymentLink>
  {
    private readonly IPaymentRepository _repository;

    public GetPaymentLinkRequestHandler(IPaymentRepository repository)
    {
      _repository = repository;
    }

    public async Task<PaymentLink> Handle(GetPaymentLinkRequestModel request, CancellationToken cancellationToken)
    {
      return await _repository.GetPaymentLinkAsync(request.PaymentLinkRef);
    }
  }
}
