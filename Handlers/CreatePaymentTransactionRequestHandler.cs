using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Webbpay.Api.PaymentService.Models.Dtos;
using Webbpay.Api.PaymentService.Extensions;
using System.Threading;
using Webbpay.Api.PaymentService.Repositories;
using Webbpay.Api.PaymentService.Entities;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Webbpay.Api.PaymentService.Mappers;
using Webbpay.Api.PaymentService.Models.Commands;

namespace Webbpay.Api.PaymentService.Handlers
{
    public class CreatePaymentTransactionRequestHandler : IRequestHandler<CreatePaymentTransactionCommand>
    {
        private readonly IPaymentRepository _repository;
        private readonly IHttpContextAccessor _httpContext;

        public CreatePaymentTransactionRequestHandler(IPaymentRepository repository, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _httpContext = httpContext;
        }

        public async Task<Unit> Handle(CreatePaymentTransactionCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContext.HttpContext.User.GetUserId();            

            var paymentTransaction = request.TransactionModel.ToEntity();
            paymentTransaction.CreatedBy = userId;

            await _repository.CreatePaymentTransactionAsync(paymentTransaction);
            return Unit.Value;
        }
    }
}
