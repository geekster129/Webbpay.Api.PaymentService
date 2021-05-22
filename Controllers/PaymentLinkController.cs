using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webbpay.Api.PaymentService.Extensions;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Adapters.UserProfile;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentLinkController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserProfileAdapter _adapter;

        public PaymentLinkController(IMediator mediator, IUserProfileAdapter adapter)
        {
            _mediator = mediator;
            _adapter = adapter;
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
        public async Task<ActionResult> Get(string paymentLinkRef)
        {
            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            var userId = HttpContext.User.GetUserId();
            await _mediator.Send(new GetPaymentLinkRequestModel(paymentLinkRef));
            return Ok();
        }


  }
}
