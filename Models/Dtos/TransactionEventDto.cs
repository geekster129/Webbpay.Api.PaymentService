using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Models.Dtos
{
    public class TransactionEventDto
    {
      
        public Guid Id { get; set; }

        [Required]
        public Guid PaymentTransactionId { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public string CreatedBy { get; set; }

        /// <summary>
        /// Any data to just pump in
        /// </summary>
        public string EventData { get; set; }
        
        public virtual PaymentTransactionDto Payment { get; set; }
    }
}
