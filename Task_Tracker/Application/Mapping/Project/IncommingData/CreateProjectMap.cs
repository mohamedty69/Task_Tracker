using Application.Features.Projects.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mapping.Project.IncommingData
{
    public class CreateProjectMap: Profile
    {
        public CreateProjectMap()
        {
            CreateMap<CreateProjectDto, Domain.Entities.Project>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
