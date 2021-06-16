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
using Webbpay.Api.PaymentService.Models.Queries;

namespace Webbpay.Api.PaymentService.Controllers
{
    [Route("api/paymenttransaction/{paymentTransactionId}/transaction")]
    [ApiController]
    [Authorize]
    public class TransactionEventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionEventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<TransactionEventDto>> Create(Guid paymentTransactionId, CreateTransactionEventModel @event)
        {
            var result = await _mediator.Send(new CreateTransactionEventCommand(@event));
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<TransactionEventDto>> Get(Guid paymentTransactionId)
        {
            var result = await _mediator.Send(new GetLatestTransactionEventQuery(paymentTransactionId));
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}