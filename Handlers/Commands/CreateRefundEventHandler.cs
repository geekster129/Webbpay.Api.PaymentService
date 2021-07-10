using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Extensions;
using Webbpay.Api.PaymentService.Mappers;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Models.Commands;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models.Notifications;
using Webbpay.Api.PaymentService.Repositories;

namespace Webbpay.Api.PaymentService.Handlers.Commands
{
    public class CreateRefundEventHandler : IRequestHandler<CreateRefundEventCommand, RefundEventDto>
    {
        private readonly IRefundRepository _refundRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMediator _mediator;

        public CreateRefundEventHandler(IRefundRepository refundRepository, IHttpContextAccessor httpContext, IMediator mediator)
        {
            _refundRepository = refundRepository;
            _httpContext = httpContext;
            _mediator = mediator;
        }

        public async Task<RefundEventDto> Handle(CreateRefundEventCommand request, CancellationToken cancellationToken)
        {
            var @event = request.Event.ToEntity();
            @event.Created = DateTime.UtcNow;
            @event.CreatedBy = _httpContext.HttpContext.User.GetUserId();

            @event = await _refundRepository.CreateEvent(@event);
            var model = @event.ToModel();

            // patch refund data
            var patchData = new PatchRefundTransactionModel
            {
                RefundTransactionId = @event.RefundTransactionId,
                RefundStatus = @event.RefundStatus,
                Updated = @event.Created,
                UpdatedBy = @event.CreatedBy
            };
            await _mediator.Send(new PatchRefundTransactionCommand(patchData));

            await _mediator.Publish(new RefundEventCreatedNotification(model));


            return model;
        }
    }
}
