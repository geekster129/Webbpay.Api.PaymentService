using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Webbpay.Api.PaymentService.Mappers.Statistics;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models.Queries;
using Webbpay.Api.PaymentService.Repositories;

namespace Webbpay.Api.PaymentService.Handlers.Queries
{
  public class GetPaymentLinkStatisticsQueryHandler : IRequestHandler<GetPaymentLinkStatisticsQuery, List<StatisticsDto>>
  {
    private readonly IPaymentRepository _repository;
    private readonly IStatisticsMapper _mapper;

    public GetPaymentLinkStatisticsQueryHandler(IPaymentRepository repository, IStatisticsMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<List<StatisticsDto>> Handle(GetPaymentLinkStatisticsQuery request, CancellationToken cancellationToken)
    {
      var paymentLink = await _repository.GetPaymentLinkAsync(request.PaymentLinkRef);
      return _mapper.Aggregate(paymentLink.PaymentTransactions);
    }
  }



}
