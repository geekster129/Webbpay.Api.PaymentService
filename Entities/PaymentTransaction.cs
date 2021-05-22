using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webbpay.Api.PaymentService.Entities
{
  public class PaymentTransaction
  {
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public PaymentMode PaymentMode { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public string PaymentRefNo { get; set; }
    public string PaymentRemarks { get; set; }
    public string ContactName { get; set; }
    public string ContactMobileNo { get; set; }
    public string ContactEmail { get; set; }
    public string ContactAddress { get; set; }
    public string ContactPostcode { get; set; }
    public string ContactState { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
  }

  public enum PaymentMode
  {
    EWALLET, VISA, MASTER
  }

  public enum PaymentStatus
  { 
    ACCEPTED, PENDING, FAILED, REJECTED
  }
}

