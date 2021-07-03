using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Queries
{
  public class GetAllStatisticsQuery : IRequest<List<StatisticsDto>>
  {
    public Guid StoreId { get; set; }

    public GetAllStatisticsQuery(Guid storeId)
    {
      StoreId = storeId;
    }
  }
}
