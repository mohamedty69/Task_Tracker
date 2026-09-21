using Application.Features.Task.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mapping.Task.IncomingData
{
    public class UpdateTaskMap : Profile
    {
        public UpdateTaskMap()
        {
            CreateMap<UpdateTaskDto, Domain.Entities.Task>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
