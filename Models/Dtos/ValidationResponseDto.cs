using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Models.Dtos
{
  public class ValidationResponseDto
  {
    public bool HasError { get => Message.Any(); }
    public List<Message> Message { get; set; } = new List<Message>();
  }

  public class Message
  {
    public string Key { get; set; }
    public string Description { get; set; }
  }
}
