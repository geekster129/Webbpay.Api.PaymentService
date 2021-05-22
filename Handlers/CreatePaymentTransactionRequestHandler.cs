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
  public class CreatePaymentTransactionRequestHandler : IRequestHandler<CreatePaymentTransactionRequestModel>
  {
    private readonly IPaymentRepository _repository;
    private readonly IHttpContextAccessor _httpContext;

    public CreatePaymentTransactionRequestHandler(IPaymentRepository repository, IHttpContextAccessor httpContext)
    {
      _repository = repository;
      _httpContext = httpContext;
    }

    public async Task<Unit> Handle(CreatePaymentTransactionRequestModel request, CancellationToken cancellationToken)
    {
      var userId = _httpContext.HttpContext.User.GetUserId();

      var paymentTransaction = new PaymentTransaction
      {
          
      };
      await _repository.CreatePaymentTransactionAsync(paymentTransaction);
      return Unit.Value;
    }
  }
}
