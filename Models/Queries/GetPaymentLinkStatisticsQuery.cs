using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Queries
{
  public class GetPaymentLinkStatisticsQuery : IRequest<List<StatisticsDto>>
  {
    public string PaymentLinkRef { get; set; }

    public GetPaymentLinkStatisticsQuery(string paymentLinkRef)
    {
      PaymentLinkRef = paymentLinkRef;
    }

  }
}
