using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Mappers;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models.Queries;
using Webbpay.Api.PaymentService.Repositories;

namespace Webbpay.Api.PaymentService.Handlers.Queries
{
    public class GetPaymentLinkRequestHandler : IRequestHandler<GetPaymentLinkRequestModel, PaymentLinkDto>
    {
        private readonly IPaymentRepository _repository;

        public GetPaymentLinkRequestHandler(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaymentLinkDto> Handle(GetPaymentLinkRequestModel request, CancellationToken cancellationToken)
        {
            var paymentLink = await _repository.GetPaymentLinkAsync(request.PaymentLinkRef);
            return paymentLink.ToModel();
        }
    }
}
