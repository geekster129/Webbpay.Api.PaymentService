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
  public class GetPaymentTransactionRequestHandler : IRequestHandler<GetPaymentTransactionRequestModel, List<PaymentTransactionDto>>
  {
    private readonly IPaymentRepository _repository;

    public GetPaymentTransactionRequestHandler(IPaymentRepository repository)
    {
      _repository = repository;
    }

    public async Task<List<PaymentTransactionDto>> Handle(GetPaymentTransactionRequestModel request, CancellationToken cancellationToken)
    {
      var paymentTransaction = await _repository.GetPaymentTransactionAsync(request.PaymentLinkRef);
      return paymentTransaction.Select(t => new PaymentTransactionDto
      {
          PaymentLinkRef = request.PaymentLinkRef,
          Amount = t.Amount,
          PaymentMode = t.PaymentMode.ToString(),
          PaymentRefNo = t.PaymentRefNo,
          PaymentRemarks = t.PaymentRemarks,
          PaymentStatus = t.PaymentStatus.ToString(),
          ContactEmail = t.ContactEmail,
          ContactName = t.ContactName,
          ContactPostcode = t.ContactPostcode,
          ContactState = t.ContactState

      }).ToList();
    }
  }
}
