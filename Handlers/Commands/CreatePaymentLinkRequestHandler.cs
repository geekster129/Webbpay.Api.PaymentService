using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Extensions;
using Webbpay.Api.PaymentService.Mappers;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models.Notifications;
using Webbpay.Api.PaymentService.Repositories;

namespace Webbpay.Api.PaymentService.Handlers.Commands
{
    public class CreatePaymentLinkRequestHandler : IRequestHandler<CreatePaymentLinkRequestModel>
    {
        private readonly IPaymentRepository _repository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMediator _mediator;

        public CreatePaymentLinkRequestHandler(
            IPaymentRepository repository,
            IHttpContextAccessor httpContext,
            IMediator mediator)
        {
            _repository = repository;
            _httpContext = httpContext;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreatePaymentLinkRequestModel request, CancellationToken cancellationToken)
        {
            var paymentLink = Map(request.PaymentLinkDto, request.StoreId);
            paymentLink = await _repository.CreatePaymentLinkAsync(paymentLink);
            await _mediator.Publish(new PaymentLinkCreatedNotification(paymentLink.ToModel()));
            return Unit.Value;
        }

        private PaymentLink Map(PaymentLinkDto paymentLinkDto, Guid storeId)
        {
            var userId = _httpContext.HttpContext.User.GetUserId();
            var paymentLink = paymentLinkDto.ToEntity();
            paymentLink.StoreId = storeId;
            paymentLink.CreatedBy = userId;
            paymentLink.UpdatedBy = userId;
            return paymentLink;
        }
    }
}
