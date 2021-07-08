using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        //[HttpGet("/requery/{transactionId}")]
        //[AllowAnonymous]
        //public async Task<ActionResult> Requery(Guid storeId,string transactionId = "08d941c4-2e21-4b1e-80bd-741e56ea93af")
        //{

        //    var transaction = await _mediator.Send(new GetPaymentTransactionQuery(Guid.Parse(transactionId)));
        //    var cache = await _mediator.Send(new GetPaymentLinkCacheQuery(transaction.PaymentLink.PaymentLinkRef));
        //    var paymentChannel = cache.PaymentChannels.FirstOrDefault(p => p.Id == transaction.PaymentChannelId);
        //    if (paymentChannel.GatewayType != GatewayType.Razer)
        //        return BadRequest("Not available now");

        //    var domain = paymentChannel.RazerSettings.MerchantId;
        //    var verifyKey = paymentChannel.RazerSettings.VerifyKey;
        //    var amount = transaction.Amount.ToString("#.00");
        //    var txID = transaction.PaymentRef1;

        //    var skey = MD5Hash($"{txID}{domain}{verifyKey}{amount}");

        //    return Ok($"https://api.merchant.razer.com/RMS/API/gate-query/index.php?amount={amount}&txID={txID}&domain={domain}&skey={skey}");
        //}

        //private string MD5Hash(string plaintText)
        //{
        //    string value;
        //    var sBuilder = new StringBuilder();
        //    using (var md5 = MD5.Create())
        //    {
        //        var hashedBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(plaintText));
        //        for (int i = 0; i < hashedBytes.Length; i++)
        //            sBuilder.Append(hashedBytes[i].ToString("x2"));
        //        value = sBuilder.ToString();
        //    }
        //    return value;
        //}
    }
}
