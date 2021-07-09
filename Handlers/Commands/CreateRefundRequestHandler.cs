using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Entities.Enums;
using Webbpay.Api.PaymentService.Extensions;
using Webbpay.Api.PaymentService.Mappers;
using Webbpay.Api.PaymentService.Models.Commands;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models.Notifications;
using Webbpay.Api.PaymentService.Repositories;

namespace Webbpay.Api.PaymentService.Handlers.Commands
{
    public class CreateRefundRequestHandler : IRequestHandler<CreateRefundRequestCommand, RefundTransactionDto>
    {
        private readonly IRefundRepository _refundRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateRefundRequestHandler(
            IRefundRepository refundRepository, 
            IHttpContextAccessor httpContextAccessor, 
            IMediator mediator, 
            IPaymentRepository paymentRepository)
        {
            _refundRepository = refundRepository;
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
            _paymentRepository = paymentRepository;
        }

        public async Task<RefundTransactionDto> Handle(CreateRefundRequestCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            await ValidateRefund(request);

            var refund = request.Request.ToEntity();
            refund.CreatedBy = userId;
            refund = await _refundRepository.Create(refund);

            //Create transaction event
            var @event = new RefundEvent
            {
                CreatedBy = userId,
                EventData = JsonSerializer.Serialize(request.Request),
                RefundStatus = RefundStatus.Pending,
                RefundTransactionId = refund.Id,
                IpAddress = request.Request.IpAddress,
                UserAgent = request.Request.UserAgent
            };
            await _refundRepository.CreateEvent(@event);

            //create notification
            var refundDto = refund.ToModel();
            await _mediator.Publish(new RefundRequestCreatedNotification(refundDto));
            return refundDto;
        }

        private async Task ValidateRefund(CreateRefundRequestCommand request)
        {
            // validate request
            var payment = await _paymentRepository.GetPaymentTransactionById(request.Request.PaymentTransactionId);
            if (payment == null)
                throw new NullReferenceException($"Payment transaction id {request.Request.PaymentTransactionId} does not exists");
            if (payment.PaymentStatus != PaymentStatus.ACCEPTED)
                throw new InvalidOperationException("Payment is not valid");
            if (payment.PaymentLink.StoreId != request.Request.StoreId)
                throw new InvalidOperationException($"Payment link {payment.PaymentLinkId} does not belong to store {request.Request.StoreId}");
            if (request.Request.Amount > payment.Amount)
                throw new InvalidOperationException($"Refund amount exceed payment amount");

            var refunds = await _refundRepository.RefundsByPaymentTransaction(request.Request.PaymentTransactionId);
            //if any pending refund then don't allow
            if (refunds.Any(f => f.RefundStatus == RefundStatus.Pending))
                throw new InvalidOperationException("There is a pending refund for this transaction");
            if (refunds.Any(f => f.RefundStatus == RefundStatus.Success))
            {
                var maxAmount =
                    payment.Amount -
                    refunds.Where(f => f.RefundStatus == RefundStatus.Success).Sum(f => f.Amount);
                if (request.Request.Amount > maxAmount)
                    throw new InvalidOperationException($"Refund amount exceed payment amount");
            }
        }
    }
}
