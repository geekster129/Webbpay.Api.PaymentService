using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Extensions;
using System.Threading;
using Webbpay.Api.PaymentService.Repositories;
using Webbpay.Api.PaymentService.Entities;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Webbpay.Api.PaymentService.Mappers.Profiles;

namespace Webbpay.Api.PaymentService.Handlers
{
  public class CreatePaymentLinkRequestHandler : IRequestHandler<CreatePaymentLinkRequestModel>
  {
    private readonly IPaymentRepository _repository;
    private readonly IHttpContextAccessor _httpContext;
    private readonly IMapper _mapper;

    public CreatePaymentLinkRequestHandler(IPaymentRepository repository, IHttpContextAccessor httpContext, IMapper mapper)
    {
      _repository = repository;
      _httpContext = httpContext;
      _mapper = mapper;
    }

    public async Task<Unit> Handle(CreatePaymentLinkRequestModel request, CancellationToken cancellationToken)
    {
      var paymentLink = Map(request.PaymentLinkDto, request.StoreId);
      await _repository.CreatePaymentLinkAsync(paymentLink);
      return Unit.Value;
    }

    private PaymentLink Map(PaymentLinkDto paymentLinkDto, Guid storeId)
    {
      var userId = _httpContext.HttpContext.User.GetUserId();
      var paymentLink = _mapper.Map<PaymentLink>(paymentLinkDto);
      paymentLink.StoreId = storeId;
      paymentLink.CreatedBy = Guid.Parse(userId);
      paymentLink.UpdatedBy = Guid.Parse(userId);
      return paymentLink;
    }
  }
}
