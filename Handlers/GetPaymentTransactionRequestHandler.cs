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
using AutoMapper;

namespace Webbpay.Api.PaymentService.Handlers
{
  public class GetPaymentTransactionRequestHandler : IRequestHandler<GetPaymentTransactionRequestModel, List<PaymentTransactionDto>>
  {
    private readonly IPaymentRepository _repository;
    private readonly IMapper _mapper;

    public GetPaymentTransactionRequestHandler(IPaymentRepository repository)
    {
      _repository = repository;
    }

    public async Task<List<PaymentTransactionDto>> Handle(GetPaymentTransactionRequestModel request, CancellationToken cancellationToken)
    {
      var paymentTransaction = await _repository.GetPaymentTransactionAsync(request.PaymentLinkRef);
      return paymentTransaction
              .Select(t => _mapper.Map<PaymentTransactionDto>(t))
              .ToList();
    }
  }
}
