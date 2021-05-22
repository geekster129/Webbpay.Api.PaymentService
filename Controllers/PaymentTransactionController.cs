using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webbpay.Api.PaymentService.Extensions;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Models.Dtos;
using System.Collections.Generic;

namespace Webbpay.Api.PaymentService.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentTransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PaymentTransactionDto paymentTransactionDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            await _mediator.Send(new CreatePaymentTransactionRequestModel(paymentTransactionDto));
            return Ok();
        }

        [HttpGet("{paymentLinkRef}")]
        public async Task<ActionResult<List<PaymentTransactionDto>>> Get(string paymentLinkRef)
        {
            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            var result = await _mediator.Send(new GetPaymentTransactionRequestModel(paymentLinkRef));
            return Ok(result);
        }


  }
}
