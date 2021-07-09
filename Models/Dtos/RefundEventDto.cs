using System;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Models.Dtos
{
    public class RefundEventDto
    {
        public Guid Id { get; set; }

        public Guid RefundTransactionId { get; set; }

        public RefundStatus RefundStatus { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public string CreatedBy { get; set; }

        /// <summary>
        /// Any data to just pump in
        /// </summary>
        public string EventData { get; set; }

        #region Audit fields 
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        #endregion        
    }
}
