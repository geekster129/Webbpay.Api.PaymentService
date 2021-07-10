using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Mappers.Profiles;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Mappers
{
    public static class MapperExtension
    {
        private static readonly IMapper _mapper;

        static MapperExtension()
        {
            _mapper = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile<PaymentMapperProfile>();
                    cfg.AddProfile<TransactionEventMapperProfile>();
                    cfg.AddProfile<RefundTransactionMapperProfile>();
                }
            )
            .CreateMapper();
        }

        public static PaymentLink ToEntity(this PaymentLinkDto paymentLink) =>
            _mapper.Map<PaymentLink>(paymentLink);

        public static PaymentLinkDto ToModel(this PaymentLink paymentLink) =>
            _mapper.Map<PaymentLinkDto>(paymentLink);

        public static IList<PaymentLinkDto> ToModel(this IEnumerable<PaymentLink> paymentLinks) =>
            _mapper.Map<IList<PaymentLinkDto>>(paymentLinks);

        public static PaymentTransaction PatchEntity(this PaymentTransaction paymentTransaction, PatchPaymentTransactionModel patchData) =>
            _mapper.Map(patchData, paymentTransaction);

        public static PaymentTransaction ToEntity(this PaymentTransactionDto paymentTransaction) =>
            _mapper.Map<PaymentTransaction>(paymentTransaction);

        public static PaymentTransaction ToEntity(this CreatePaymentTransactionModel paymentTransaction) =>
            _mapper.Map<PaymentTransaction>(paymentTransaction);

        public static PaymentTransactionDto ToModel(this PaymentTransaction paymentTransaction) =>
            _mapper.Map<PaymentTransactionDto>(paymentTransaction);

        public static PagedPaymentTransactionsResult ToModel(this PagedResult<PaymentTransaction> transactions) =>
            _mapper.Map<PagedPaymentTransactionsResult>(transactions);

        public static PagedPaymentLinkResult ToModel(this PagedResult<PaymentLink> paymentLinks) =>
            _mapper.Map<PagedPaymentLinkResult>(paymentLinks);

        public static TransactionEvent ToEntity(this CreateTransactionEventModel @event) =>
            _mapper.Map<TransactionEvent>(@event);

        public static TransactionEventDto ToModel(this TransactionEvent @event) =>
            _mapper.Map<TransactionEventDto>(@event);

        #region Refund 
        public static RefundTransaction ToEntity(this RefundRequestModel request) =>
            _mapper.Map<RefundTransaction>(request);

        public static RefundTransactionDto ToModel(this RefundTransaction refund) =>
            _mapper.Map<RefundTransactionDto>(refund);

        public static RefundEvent ToEntity(this CreateRefundEventModel refund) =>
            _mapper.Map<RefundEvent>(refund);

        public static RefundEventDto ToModel(this RefundEvent @event) =>
            _mapper.Map<RefundEventDto>(@event);

        public static RefundTransaction PatchEntity(this RefundTransaction refund, PatchRefundTransactionModel patchData) =>
            _mapper.Map(patchData, refund);
        #endregion
    }
}
