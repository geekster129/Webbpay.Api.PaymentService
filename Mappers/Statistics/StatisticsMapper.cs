using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Mappers.Statistics
{
  public class StatisticsMapper : IStatisticsMapper
  {
    public List<StatisticsDto> Aggregate(List<PaymentTransaction> paymentTransactions)
      => paymentTransactions.GroupBy(pt => new { pt.PaymentStatus })
          .Select(stats => new StatisticsDto
            {
              PaymentStatus = stats.Key.PaymentStatus,
              Amounts = stats.GroupBy(pt => new { pt.Created.Year, pt.Created.Month })
                              .Select(sbd => new Models.Dtos.StatisticsBreakdown
                                {
                                  Period = GetPeriod(sbd.Key.Year, sbd.Key.Month),
                                  TotalAmount = sbd.Sum(pt => pt.Amount)
                                })
                              .ToList()
            })
          .ToList();

    private string GetPeriod(int year, int month)
      => $"{year}-{month.ToString().PadLeft(2, '0')}";
  }
}
