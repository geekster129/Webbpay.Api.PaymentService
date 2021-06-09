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

        [HttpPost("testpublish")]
        public async Task<ActionResult> Publish()
        {
            var paymentLink = new PaymentLinkDto
            {
                Id = Guid.NewGuid(),
                StoreId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                ExpiryDate = DateTime.Now.AddYears(1),
                Amount = 100.0M,
                Quantity = 100
            };
            await _mediator.Publish(new PaymentLinkCreatedNotification(paymentLink));
            return Ok();
        }

  }
}
