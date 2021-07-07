using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Mappers.Statistics
{
  public interface IStatisticsMapper
  {
    public List<StatisticsDto> Aggregate(List<PaymentTransaction> paymentTransactions);
  }
}
