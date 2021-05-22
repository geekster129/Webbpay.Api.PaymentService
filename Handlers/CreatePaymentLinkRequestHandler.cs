using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models;
using System.Threading;
using Webbpay.Api.PaymentService.Repositories;
using Webbpay.Api.PaymentService.Entities;

namespace Webbpay.Api.PaymentService.Handlers
{
  public class CreatePaymentLinkRequestHandler : IRequestHandler<CreatePaymentLinkRequestModel>
  {
    private readonly IPaymentRepository _repository;

    public CreatePaymentLinkRequestHandler(IPaymentRepository repository)
    {
      _repository = repository;
    }

    public async Task<Unit> Handle(CreatePaymentLinkRequestModel request, CancellationToken cancellationToken)
    {
      var paymentLink = new PaymentLink
      {
          StoreId = request.PaymentLinkDto.StoreId,
          PaymentLinkRef = request.PaymentLinkDto.PaymentLinkRef,
          InventoryId = request.PaymentLinkDto.InventoryId,
          ExpiryDate = request.PaymentLinkDto.ExpiryDate,
          Quantity = request.PaymentLinkDto.Quantity,
          Amount = request.PaymentLinkDto.Amount,
          CreatedBy = Guid.Parse(request.UserId),
          UpdatedBy = Guid.Parse(request.UserId),
      };
      await _repository.CreatePaymentLinkAsync(paymentLink);
      return Unit.Value;
    }
  }
}
