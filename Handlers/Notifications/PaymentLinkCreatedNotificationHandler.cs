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
    public class PaymentLinkCreatedNotificationHandler : INotificationHandler<PaymentLinkCreatedNotification>
    {
        private readonly IAmazonSimpleNotificationService _amazonSimpleNotificationService;
        private readonly ILogger<PaymentLinkCreatedNotificationHandler> _logger;

        public PaymentLinkCreatedNotificationHandler(
            IAmazonSimpleNotificationService amazonSimpleNotificationService, 
            ILogger<PaymentLinkCreatedNotificationHandler> logger)
        {
            _amazonSimpleNotificationService = amazonSimpleNotificationService;
            _logger = logger;
        }

        public async Task Handle(PaymentLinkCreatedNotification notification, CancellationToken cancellationToken)
        {
            string arn = Environment.GetEnvironmentVariable("webbpay_sns_paymentlink_created");

            if (string.IsNullOrEmpty(arn))
            {

                _logger.LogError($"Variable not set for subject: 'PaymentLinkCreatedNotification'");
                return;
            }
            var request = new PublishRequest
            {
                Message = JsonSerializer.Serialize(
                    notification.PaymentLink,
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    }
                    ),
                TopicArn = arn
            };            
            var response = await _amazonSimpleNotificationService.PublishAsync(request);
            if(response.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {
                _logger.LogError("Unable to publish SNS message");
            }
        }
    }
}
