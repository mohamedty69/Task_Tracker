using Application.Features.Task.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Application.Mapping.Task.IncomingData
{
    public class CreateTaskMap : Profile
    {
        public CreateTaskMap()
        {
            CreateMap<CreateTaskDto, Domain.Entities.Task>()
                .ForMember(dest => dest.CreatedAt,opt => opt.MapFrom(src => DateTime.UtcNow ));
               
        }
    }
}
