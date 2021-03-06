using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Models.Dtos
{
  public class StatisticsDto
  {
    public PaymentStatus PaymentStatus { get; set; }
    public IList<StatisticsBreakdown> Amounts { get; set; }
  }

  public class StatisticsBreakdown
  {
    public string Period { get; set; }
    public decimal TotalAmount { get; set; }
  }
}
