using AutoMapper;
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
  public class GetPaymentLinkRequestHandler : IRequestHandler<GetPaymentLinkRequestModel, PaymentLinkDto>
  {
    private readonly IPaymentRepository _repository;
    private readonly IMapper _mapper;

    public GetPaymentLinkRequestHandler(IPaymentRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<PaymentLinkDto> Handle(GetPaymentLinkRequestModel request, CancellationToken cancellationToken)
    {
      var paymentLink = await _repository.GetPaymentLinkAsync(request.PaymentLinkRef);
      return _mapper.Map<PaymentLinkDto>(paymentLink);      
    }
  }
}
