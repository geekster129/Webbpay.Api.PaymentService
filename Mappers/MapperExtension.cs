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

        


    }
}
