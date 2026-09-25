using Application.Features.Auth.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mapping.Auth
{
    public class RegisterUserMap : Profile
    {
        public RegisterUserMap()
        {
            CreateMap<RegisterDto, ApplicationUser>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName +" "+ src.LastName}"));
        }
    }
}
