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
using System.Collections.Generic;

namespace Webbpay.Api.PaymentService.Controllers
{
    [Route("api/store/{storeId}/[controller]")]
    [Authorize]
    public class PaymentLinkController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentLinkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Guid storeId, [FromBody] PaymentLinkDto paymentLinkDto)
        {          
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var validationResult = await _mediator.Send(new CheckPaymentLinkParamsValidRequestModel(storeId, paymentLinkDto.ProductId, paymentLinkDto.PaymentLinkRef));
            if(validationResult.HasError) 
            { 
              validationResult.Message.ForEach(m => ModelState.AddModelError(m.Key, m.Description));
              return BadRequest(ModelState);
            }

            await _mediator.Send(new CreatePaymentLinkRequestModel(paymentLinkDto, storeId));
            return Ok();
        }

        [HttpGet("{paymentLinkRef}")]
        public async Task<ActionResult<PaymentLinkDto>> Get(string paymentLinkRef)
        {
            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            var result = await _mediator.Send(new GetPaymentLinkRequestModel(paymentLinkRef));
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IList<PaymentLinkDto>>> Get(Guid storeId, IList<Guid> paymentlinkId)
        {
            var result = await _mediator.Send(new GetPaymentLinksQuery(storeId, paymentlinkId));
            return Ok(result);
        }

        [HttpGet("/api/paymentlink/{paymentLinkRef}/cache")]
        public async Task<ActionResult> GetCache(string paymentLinkRef)
        {
            var result = await _mediator.Send(new GetPaymentLinkCacheQuery(paymentLinkRef));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult> Search(Guid storeId, PaymentLinkStatus status = PaymentLinkStatus.Active, int page = 1, int pageSize = 10)
        {
            var result = await _mediator.Send(new SearchPaymentLinksQuery(storeId, status, page, pageSize));

            return Ok(result);
        }

  }
}
