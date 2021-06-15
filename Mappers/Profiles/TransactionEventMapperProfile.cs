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
    public class TransactionEventMapperProfile : Profile
    {
        public TransactionEventMapperProfile()
        {
            CreateMap<TransactionEvent, TransactionEventDto>().ReverseMap();
            CreateMap<CreateTransactionEventModel, TransactionEvent>();
        }
    }
}
