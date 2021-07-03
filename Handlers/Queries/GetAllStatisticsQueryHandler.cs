using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Repositories;
using MediatR;
using Webbpay.Api.PaymentService.Models.Queries;
using Webbpay.Api.PaymentService.Models.Dtos;
using System.Threading;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Mappers.Statistics;

namespace Webbpay.Api.PaymentService.Handlers.Queries
{
  public class GetAllStatisticsQueryHandler : IRequestHandler<GetAllStatisticsQuery, List<StatisticsDto>>
  {
    private readonly IPaymentRepository _repository;
    private readonly IStatisticsMapper _mapper;

    public GetAllStatisticsQueryHandler(IPaymentRepository repository, IStatisticsMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<List<StatisticsDto>> Handle(GetAllStatisticsQuery request, CancellationToken cancellationToken)
    {
      var paymentTransactions = await _repository.GetPaymentTransactionsByStoreAsync(request.StoreId);
      return _mapper.Aggregate(paymentTransactions);
    }
  }
}
