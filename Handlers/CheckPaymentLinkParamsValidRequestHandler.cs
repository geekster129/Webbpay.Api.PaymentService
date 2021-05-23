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
using Webbpay.Api.PaymentService.Adapters.Store;
using Webbpay.Api.PaymentService.Adapters.Inventory;

namespace Webbpay.Api.PaymentService.Handlers
{
  public class CheckPaymentLinkParamsValidRequestHandler : IRequestHandler<CheckPaymentLinkParamsValidRequestModel, ValidationResponseDto>
  {
    private readonly IPaymentRepository _repository;
    private readonly IHttpContextAccessor _httpContext;
    private readonly IStoreAdapter _storeAdapter;
    private readonly IInventoryAdapter _inventoryAdapter;

    public CheckPaymentLinkParamsValidRequestHandler(IPaymentRepository repository, IHttpContextAccessor httpContext, IStoreAdapter storeAdapter, IInventoryAdapter inventoryAdapter)
    {
      _repository = repository;
      _httpContext = httpContext;
      _storeAdapter = storeAdapter;
      _inventoryAdapter = inventoryAdapter;
    }

    public async Task<ValidationResponseDto> Handle(CheckPaymentLinkParamsValidRequestModel request, CancellationToken cancellationToken)
    {
      var validationResp = new ValidationResponseDto();
      var store = await _storeAdapter.GetStore(request.StoreId);
      var inventory = await _inventoryAdapter.GetInventory(request.InventoryId);
      var paymentLink = await _repository.GetPaymentLinkAsync(request.PaymentLinkRef);
      if (store==null)
        validationResp.Message.Add(new Message { Key = "StoreId validation", Description = "StoreId doesn't exists!" });
      if (inventory==null)
        validationResp.Message.Add(new Message { Key = "InventoryId validation", Description = "InventoryId doesn't exists!" });
      if(paymentLink!=null)
        validationResp.Message.Add(new Message { Key = "PaymentLinkRef validation", Description = "PaymentLinkRef already exists!" });
      return validationResp;

    }
  }
}
