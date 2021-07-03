using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webbpay.Api.PaymentService.Extensions;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Entities;
using System.Linq;
using System;
using Webbpay.Api.PaymentService.Models.Notifications;
using Webbpay.Api.PaymentService.Models.Queries;
using Webbpay.Api.PaymentService.Models.Commands;
using Webbpay.Api.PaymentService.Entities.Enums;
using Webbpay.Api.PaymentService.Repositories;
using System.Collections.Generic;

namespace Webbpay.Api.PaymentService.Controllers
{
  [Route("api/store/{storeId}/[controller]")]
  [Authorize]
  public class StatisticsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public StatisticsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<Statistics>>> GetAllPaymentStats(Guid storeId)
    {
      var result = await _mediator.Send(new GetAllStatisticsQuery(storeId));
      return Ok(result);
    }

    [HttpGet("PaymentLink/{paymentLinkRef}")]
    public async Task<ActionResult<List<Statistics>>> GetPaymentLinkStats(string paymentLinkRef)
    {
      var result = await _mediator.Send(new GetPaymentLinkStatisticsQuery(paymentLinkRef));
      return Ok(result);
    }
  }
}
