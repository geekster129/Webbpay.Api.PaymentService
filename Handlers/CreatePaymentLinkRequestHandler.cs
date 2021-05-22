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

namespace Webbpay.Api.PaymentService.Handlers
{
  public class CreatePaymentLinkRequestHandler : IRequestHandler<CreatePaymentLinkRequestModel>
  {
    private readonly IPaymentRepository _repository;
    private readonly IHttpContextAccessor _httpContext;

    public CreatePaymentLinkRequestHandler(IPaymentRepository repository, IHttpContextAccessor httpContext)
    {
      _repository = repository;
      _httpContext = httpContext;
    }

    public async Task<Unit> Handle(CreatePaymentLinkRequestModel request, CancellationToken cancellationToken)
    {
      var userId = _httpContext.HttpContext.User.GetUserId();

      var paymentLink = new PaymentLink
      {
          StoreId = request.PaymentLinkDto.StoreId,
          PaymentLinkRef = request.PaymentLinkDto.PaymentLinkRef,
          InventoryId = request.PaymentLinkDto.InventoryId,
          ExpiryDate = request.PaymentLinkDto.ExpiryDate,
          Quantity = request.PaymentLinkDto.Quantity,
          Amount = request.PaymentLinkDto.Amount,
          PaymentTransactions = new List<PaymentTransaction>(),
          CreatedBy = Guid.Parse(userId),
          UpdatedBy = Guid.Parse(userId),
      };
      await _repository.CreatePaymentLinkAsync(paymentLink);
      return Unit.Value;
    }
  }
}
