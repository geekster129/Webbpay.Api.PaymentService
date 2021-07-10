using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models.Notifications;

namespace Webbpay.Api.PaymentService.Handlers.Notifications
{
    public class RefundEventCreatedNotificationHandler : INotificationHandler<RefundEventCreatedNotification>
    {
        private readonly IAmazonSimpleNotificationService _amazonSimpleNotificationService;
        private readonly ILogger<RefundRequestCreatedNotificationHandler> _logger;

        public RefundEventCreatedNotificationHandler(IAmazonSimpleNotificationService amazonSimpleNotificationService, ILogger<RefundRequestCreatedNotificationHandler> logger)
        {
            _amazonSimpleNotificationService = amazonSimpleNotificationService;
            _logger = logger;
        }

        public async Task Handle(RefundEventCreatedNotification notification, CancellationToken cancellationToken)
        {
            string arn = Environment.GetEnvironmentVariable("webbpay_sns_refundevent_created");

            if (string.IsNullOrEmpty(arn))
            {

                _logger.LogError($"Variable not set for subject: 'RefundEventCreatedNotification'");
                return;
            }
            var request = new PublishRequest
            {
                Message = JsonSerializer.Serialize(
                    notification.Event,
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
