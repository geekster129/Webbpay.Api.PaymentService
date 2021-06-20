using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Models.Commands;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models.Queries;

namespace Webbpay.Api.PaymentService.Controllers
{
    [Route("api/store/{storeId}/[controller]")]
    [Authorize]
    public class PaymentTransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePaymentTransactionModel paymentTransactionDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            await _mediator.Send(new CreatePaymentTransactionCommand(paymentTransactionDto));
            return Ok();
        }

        [HttpGet("search")]
        public async Task<ActionResult<PagedPaymentTransactionsResult>> Search(
            Guid storeId,
            PaymentStatus? paymentStatus = PaymentStatus.ACCEPTED,
            Guid? paymentLinkId = null, 
            Guid? productId = null, 
            int page = 1, int pageSize = 10)
        {
            var result = await _mediator.Send(new SearchPaymentTransactionQuery(
                storeId,
                paymentStatus,
                paymentLinkId,
                productId,
                page,
                pageSize
                ));
            return Ok(result);
        }
 
        [HttpGet("{paymentLinkRef}")]
        public async Task<ActionResult<List<PaymentTransactionDto>>> Get(string paymentLinkRef)
        {
            if (!ModelState.IsValid)
              return BadRequest(ModelState);
            var result = await _mediator.Send(new GetPaymentTransactionRequestModel(paymentLinkRef));
            return Ok(result);
        }

        [HttpGet("/api/paymenttransaction/{orderNo}/order-no")]
        public async Task<ActionResult<PaymentTransactionDto>> GetByOrderNo(string orderNo)
        {
            var result = await _mediator.Send(new GetPaymentTransactionByOrderNoQuery(orderNo));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("{transactionId}")]
        public async Task<ActionResult<PaymentTransactionDto>> PatchTransaction(Guid transactionId, [FromBody] PatchPaymentTransactionModel patchData)
        {
            var result = await _mediator.Send(new PatchPaymentTransactionCommand(patchData));

            return Ok(result);
        }

  }
}
