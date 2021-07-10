using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Extensions;
using Webbpay.Api.PaymentService.Mappers;
using Webbpay.Api.PaymentService.Models.Commands;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Repositories;

namespace Webbpay.Api.PaymentService.Handlers.Commands
{
    public class CreateRefundEventHandler : IRequestHandler<CreateRefundEventCommand, RefundEventDto>
    {
        private readonly IRefundRepository _refundRepository;
        private readonly IHttpContextAccessor _httpContext;

        public CreateRefundEventHandler(IRefundRepository refundRepository, IHttpContextAccessor httpContext)
        {
            _refundRepository = refundRepository;
            _httpContext = httpContext;
        }

        public async Task<RefundEventDto> Handle(CreateRefundEventCommand request, CancellationToken cancellationToken)
        {
            var @event = request.Event.ToEntity();
            @event.Created = DateTime.UtcNow;
            @event.CreatedBy = _httpContext.HttpContext.User.GetUserId();

            @event = await _refundRepository.CreateEvent(@event);
            var model = @event.ToModel();

            return model;
        }
    }
}
