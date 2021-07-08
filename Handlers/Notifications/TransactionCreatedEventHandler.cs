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
    public class TransactionCreatedEventHandler : INotificationHandler<TransactionCreatedEvent>
    {
        private readonly IAmazonSimpleNotificationService _amazonSimpleNotificationService;
        private readonly ILogger<TransactionCreatedEventHandler> _logger;

        public TransactionCreatedEventHandler(
            IAmazonSimpleNotificationService amazonSimpleNotificationService, 
            ILogger<TransactionCreatedEventHandler> logger)
        {
            _amazonSimpleNotificationService = amazonSimpleNotificationService;
            _logger = logger;
        }

        public async Task Handle(TransactionCreatedEvent notification, CancellationToken cancellationToken)
        {
            var arn = Environment.GetEnvironmentVariable("webbpay_sns_transaction_created");
            if (string.IsNullOrEmpty(arn))
            {

                _logger.LogError($"Variable not set for subject: 'PaymentLinkCreatedNotification'");
                return;
            }
            var request = new PublishRequest
            {
                Message = JsonSerializer.Serialize(
                    notification.PaymentTransaction,
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
