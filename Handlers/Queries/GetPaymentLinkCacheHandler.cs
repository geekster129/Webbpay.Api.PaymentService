using Amazon.S3;
using Amazon.S3.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Models.Queries;

namespace Webbpay.Api.PaymentService.Handlers.Queries
{
    public class GetPaymentLinkCacheHandler : IRequestHandler<GetPaymentLinkCacheQuery, PaymentlinkCacheModel>
    {
        private readonly IAmazonS3 _amazonS3;
        private readonly ILogger<GetPaymentLinkCacheHandler> _logger;
        private readonly string _bucket = "paymentlink-cache";//Environment.GetEnvironmentVariable("webbpay_payment_link_cache_bucket");

        public GetPaymentLinkCacheHandler(IAmazonS3 amazonS3, ILogger<GetPaymentLinkCacheHandler> logger)
        {
            _amazonS3 = amazonS3;
            _logger = logger;
        }

        public async Task<PaymentlinkCacheModel> Handle(GetPaymentLinkCacheQuery request, CancellationToken cancellationToken)
        {

            try
            {
                GetObjectRequest req = new GetObjectRequest
                {
                    BucketName = _bucket,
                    Key = $"{request.PaymentLinkRef}.json"
                };
                using (GetObjectResponse response = await _amazonS3.GetObjectAsync(req))
                using (Stream responseStream = response.ResponseStream)
                {
                    return await JsonSerializer.DeserializeAsync<PaymentlinkCacheModel>(responseStream);
                }
            }
            catch (AmazonS3Exception e)
            {
                return null;            
            }
            catch (Exception e)
            {
                _logger.LogError("Unknown encountered on server. Message:'{0}' when reading object", e.Message);
                return null;
            }
        }
    }
}
