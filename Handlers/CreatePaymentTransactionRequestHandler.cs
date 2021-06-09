using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Extensions;
using System.Threading;
using Webbpay.Api.PaymentService.Repositories;
using Webbpay.Api.PaymentService.Entities;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Webbpay.Api.PaymentService.Mappers;

namespace Webbpay.Api.PaymentService.Handlers
{
    public class CreatePaymentTransactionRequestHandler : IRequestHandler<CreatePaymentTransactionRequestModel>
    {
        private readonly IPaymentRepository _repository;
        private readonly IHttpContextAccessor _httpContext;

        public CreatePaymentTransactionRequestHandler(IPaymentRepository repository, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _httpContext = httpContext;
        }

        public async Task<Unit> Handle(CreatePaymentTransactionRequestModel request, CancellationToken cancellationToken)
        {
            var userId = _httpContext.HttpContext.User.GetUserId();
            if (request.PaymentTransactionDto.PaymentLinkRef == null)
                return Unit.Value;

            var paymentTransaction = request.PaymentTransactionDto.ToEntity();
            paymentTransaction.CreatedBy = Guid.Parse(userId);

            await _repository.CreatePaymentTransactionAsync(paymentTransaction, request.PaymentTransactionDto.PaymentLinkRef);
            return Unit.Value;
        }
    }
}
