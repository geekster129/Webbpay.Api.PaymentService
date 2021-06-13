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
                }
            )
            .CreateMapper();
        }

        public static PaymentLink ToEntity(this PaymentLinkDto paymentLink) =>
            _mapper.Map<PaymentLink>(paymentLink);

        public static PaymentLinkDto ToModel(this PaymentLink paymentLink) =>
            _mapper.Map<PaymentLinkDto>(paymentLink);

        public static PaymentTransaction ToEntity(this PaymentTransactionDto paymentTransaction) =>
            _mapper.Map<PaymentTransaction>(paymentTransaction);

        public static PaymentTransactionDto ToModel(this PaymentTransaction paymentTransaction) =>
            _mapper.Map<PaymentTransactionDto>(paymentTransaction);

        public static PagedPaymentLinkResult ToModel(this PagedResult<PaymentLink> paymentLinks) =>
            _mapper.Map<PagedPaymentLinkResult>(paymentLinks);
    }
}
