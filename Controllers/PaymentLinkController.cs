using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webbpay.Api.PaymentService.Extensions;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Entities;

namespace Webbpay.Api.PaymentService.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentLinkController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentLinkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PaymentLinkDto paymentLinkDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = HttpContext.User.GetUserId();
            await _mediator.Send(new CreatePaymentLinkRequestModel(userId, paymentLinkDto));
            return Ok();
        }

        [HttpGet("{paymentLinkRef}")]
        public async Task<ActionResult<PaymentLink>> Get(string paymentLinkRef)
        {
            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            var result = await _mediator.Send(new GetPaymentLinkRequestModel(paymentLinkRef));
            return Ok(result);
        }

  }
}
