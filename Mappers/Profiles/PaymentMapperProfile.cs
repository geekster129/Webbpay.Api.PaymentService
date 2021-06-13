using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
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
        }
    }
}
