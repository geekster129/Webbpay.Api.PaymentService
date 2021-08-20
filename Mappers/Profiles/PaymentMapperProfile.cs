using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Entities.Enums;
using Webbpay.Api.PaymentService.Models;
using Webbpay.Api.PaymentService.Models.Dtos;

namespace Webbpay.Api.PaymentService.Mappers.Profiles
{
    public class PaymentMapperProfile : Profile
    {
        public PaymentMapperProfile()
        {
            CreateMap<PaymentLinkDto, PaymentLink>();
            CreateMap<PaymentLink, PaymentLinkDto>();
            CreateMap<PaymentTransaction, PaymentTransactionDto>();
            CreateMap<PaymentTransactionDto, PaymentTransaction>();
            CreateMap<PagedResult<PaymentLink>, PagedPaymentLinkResult>();
            CreateMap<CreatePaymentTransactionModel, PaymentTransaction>()
                .ForMember(t => t.PaymentStatus, opt => opt.MapFrom(t => PaymentStatus.PENDING));

            CreateMap<PatchPaymentTransactionModel, PaymentTransaction>()
                .ForMember(f => f.PaymentChannel, opt => opt.Condition(s => !string.IsNullOrEmpty(s.PaymentChannel)))
                .ForMember(f => f.PaymentRef1, opt => opt.Condition(s => !string.IsNullOrEmpty(s.PaymentRef1)))
                .ForMember(f => f.PaymentRef2, opt => opt.Condition(s => !string.IsNullOrEmpty(s.PaymentRef2)))
                .ForMember(f => f.PaymentRef3, opt => opt.Condition(s => !string.IsNullOrEmpty(s.PaymentRef3)));

            CreateMap<PagedResult<PaymentTransaction>, PagedPaymentTransactionsResult>();
        }
    }
}
