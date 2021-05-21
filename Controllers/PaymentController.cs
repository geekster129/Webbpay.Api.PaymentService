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
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserProfileAdapter _adapter;

        public PaymentController(IMediator mediator, IUserProfileAdapter adapter)
        {
            _mediator = mediator;
            _adapter = adapter;
        }

        // POST api/values
        [HttpPost("create-payment-link")]
        public async Task<ActionResult> Post([FromBody] PaymentLinkDto paymentLinkDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = HttpContext.User.GetUserId();
            await _mediator.Send(new CreatePaymentLinkRequestModel(paymentLinkDto));
            return Ok();
        }
     

    }
}
