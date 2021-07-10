using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Models.Commands;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Controllers
{
    [Route("api/refundtransaction/{refundTransactionId}/event")]
    [ApiController]
    [Authorize]
    public class RefundEventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RefundEventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<RefundEventDto>> Create(Guid refundTransactionId, CreateRefundEventModel @event)
        {
            var result = await _mediator.Send(new CreateRefundEventCommand(@event));
            return Ok(result);
        } 
    }
}
