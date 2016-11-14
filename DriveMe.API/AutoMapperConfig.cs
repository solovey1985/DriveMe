﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Bigly.Domain.Models;
using Bigly.GUI.ViewModels;

namespace Bigly.Api
{
    internal static class AutoMapperConfig
    {
        internal static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<PaymentProfile>();
             });
        }
    }

    public class PaymentProfile : Profile
    {


        protected override void Configure()
        {
            CreateMap<SalaryViewModel, Salary>();
                
            CreateMap<Salary, SalaryViewModel>()
                    .ForMember(m => m.Since, opt => opt.MapFrom(x => x.Period.Since))
                    .ForMember(m => m.Till, opt => opt.MapFrom(x => x.Period.Till))
                    .ForMember(m => m.FirstName, opt => opt.MapFrom(x => x.Employee.FirstName))
                    .ForMember(m => m.LastName, opt => opt.MapFrom(x => x.Employee.LastName))

                    ;
        }
    }

}