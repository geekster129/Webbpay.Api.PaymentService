using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Models.Commands;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models.Queries;

namespace Webbpay.Api.PaymentService.Controllers
{
    [Route("api/store/{storeId}/refund")]
    [ApiController]
    [Authorize]
    public class RefundController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RefundController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<RefundTransactionDto>> Create(RefundRequestModel request)
        {
            try
            {
                return Ok(await _mediator.Send(new CreateRefundRequestCommand(request)));
            } catch(Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest(ModelState);
            }           
        }

        [HttpPut("/api/refund/{refundtransactionId}")]
        public async Task<ActionResult<RefundTransactionDto>> PatchRefundTransaction(Guid refundtransactionId, PatchRefundTransactionModel patchData)
        {
            if(refundtransactionId!=patchData.RefundTransactionId)
            {
                ModelState.AddModelError("Error", "Id does not match");
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(new PatchRefundTransactionCommand(patchData));
            return Ok(result);
        }

        [HttpGet("/api/refund/search")]
        public async Task<ActionResult<PagedRefundTransactionResult>> Search(RefundStatus status, int page = 1, int pageSize = 10)
        {
            var result = await _mediator.Send(new SearchRefundTransactionQuery(status, page, pageSize));
            return Ok(result);
        }

    }
}
