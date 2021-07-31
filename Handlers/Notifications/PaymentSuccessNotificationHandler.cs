using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Notifications;

namespace Webbpay.Api.PaymentService.Handlers.Notifications
{
    public class PaymentSuccessNotificationHandler : INotificationHandler<PaymentSuccessNotification>
    {
        private readonly IAmazonSimpleNotificationService _amazonSimpleNotificationService;
        private readonly ILogger<RefundRequestCreatedNotificationHandler> _logger;

        public PaymentSuccessNotificationHandler(IAmazonSimpleNotificationService amazonSimpleNotificationService, ILogger<RefundRequestCreatedNotificationHandler> logger)
        {
            _amazonSimpleNotificationService = amazonSimpleNotificationService;
            _logger = logger;
        }

        public async Task Handle(PaymentSuccessNotification notification, CancellationToken cancellationToken)
        {
            string arn = Environment.GetEnvironmentVariable("webbpay_sns_payment_success");

            if (string.IsNullOrEmpty(arn))
            {

                _logger.LogError($"Variable not set for subject: 'PaymentSuccessNotificationHandler'");
                return;
            }
            var request = new PublishRequest
            {
                Message = JsonSerializer.Serialize(
                    notification.Payment,
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    }
                    ),
                TopicArn = arn
            };
            var response = await _amazonSimpleNotificationService.PublishAsync(request);
            if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {
                _logger.LogError("Unable to publish SNS message");
            }
        }
    }
}
