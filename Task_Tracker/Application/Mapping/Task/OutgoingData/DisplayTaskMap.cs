using Application.Features.Task.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mapping.Task.OutgoingData
{
    public class DisplayTaskMap : Profile
    {
        public DisplayTaskMap()
        {
            CreateMap<Domain.Entities.Task, TaskDto>();
        }
    }
}
