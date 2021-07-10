using MediatR;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Models.Notifications
{
    public class RefundEventCreatedNotification : INotification
    {
        public RefundEventCreatedNotification(RefundEventDto @event)
        {
            Event = @event;
        }

        public RefundEventDto Event { get; }
    }
}
