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
    public class RefundTransactionMapperProfile : Profile
    {
        public RefundTransactionMapperProfile()
        {
            CreateMap<RefundTransaction, RefundTransactionDto>().ReverseMap();
            CreateMap<RefundEvent, RefundEventDto>().ReverseMap();
            CreateMap<RefundRequestModel, RefundTransaction>()
                .ForMember(f => f.Id, opt => opt.MapFrom(f => Guid.NewGuid()))
                .ForMember(f => f.RefundStatus, opt => opt.MapFrom(f => RefundStatus.Pending))
                .ForMember(f => f.ExternalRefNo, opt => opt.MapFrom(f => KeyGenerator.GetUniqueKey(10)));
            CreateMap<CreateRefundEventModel, RefundEvent>();
            CreateMap<PatchRefundTransactionModel, RefundTransaction>();
        }
    }
}
