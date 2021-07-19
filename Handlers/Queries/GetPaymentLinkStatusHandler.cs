using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;
using Webbpay.Api.PaymentService.Extensions;
using Webbpay.Api.PaymentService.Mappers;
using Webbpay.Api.PaymentService.Models.Notifications;
using Webbpay.Api.PaymentService.Models.Queries;
using Webbpay.Api.PaymentService.Repositories;

namespace Webbpay.Api.PaymentService.Handlers.Queries
{
    public class GetPaymentLinkStatusHandler : IRequestHandler<GetPaymentLinkStatusQuery, PaymentLinkStatus>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;

        public GetPaymentLinkStatusHandler(IPaymentRepository paymentRepository, IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _paymentRepository = paymentRepository;
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        public async Task<PaymentLinkStatus> Handle(GetPaymentLinkStatusQuery request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            // get payment link
            var paymentLink = await _paymentRepository.GetPaymentLinkAsync(request.PaymentlinkRef);

            paymentLink.Updated = DateTime.UtcNow;
            paymentLink.UpdatedBy = userId;

            var pendingOrders = await _paymentRepository.SearchPaymentTransactionAsync(
               paymentLink.StoreId,
               PaymentStatus.PENDING,
               paymentLinkId: paymentLink.Id,
               page: 1,
               pageSize: 0
               );

            // if deleted or inactive then return status as triggered by user or system expired
            if (paymentLink.Status == PaymentLinkStatus.Inactive ||
                paymentLink.Status == PaymentLinkStatus.Deleted  ||
                paymentLink.Status == PaymentLinkStatus.Expired
                )
                return paymentLink.Status;          
            
            // if status is still active but expired
            if (paymentLink.Status == PaymentLinkStatus.Active &&
                paymentLink.ExpiryDate.HasValue && paymentLink.ExpiryDate <= DateTime.UtcNow)
            {
                paymentLink.Status = PaymentLinkStatus.Expired;
                paymentLink = await _paymentRepository.UpdatePaymentLinkAsync(paymentLink);
                await _mediator.Publish(new PaymentLinkCreatedNotification(paymentLink.ToModel()));
                return PaymentLinkStatus.Expired;
            }
                
            // do not need to check quantity if it is zero
            if (paymentLink.SuccessfulTransactions == 0)
                return paymentLink.Status;

            //check all orders
            var successOrders = await _paymentRepository.SearchPaymentTransactionAsync(
                paymentLink.StoreId,
                PaymentStatus.ACCEPTED,
                paymentLinkId: paymentLink.Id,
                page: 1,
                pageSize: 0
                );       


            if(paymentLink.Status == PaymentLinkStatus.Active && 
                pendingOrders.Total + successOrders.Total >= paymentLink.SuccessfulTransactions)
            {
                paymentLink.Status = PaymentLinkStatus.QuoteMaxed;
                paymentLink = await _paymentRepository.UpdatePaymentLinkAsync(paymentLink);
                await _mediator.Publish(new PaymentLinkCreatedNotification(paymentLink.ToModel()));
                return paymentLink.Status;
            }

            if(paymentLink.Status == PaymentLinkStatus.QuoteMaxed &&
                pendingOrders.Total + successOrders.Total < paymentLink.SuccessfulTransactions)
            {
                paymentLink.Status = PaymentLinkStatus.Active;
                paymentLink = await _paymentRepository.UpdatePaymentLinkAsync(paymentLink);
                await _mediator.Publish(new PaymentLinkCreatedNotification(paymentLink.ToModel()));
                return paymentLink.Status;
            }

            return paymentLink.Status;
        }
    }
}
