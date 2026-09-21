using Application.Features.Projects.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mapping.Project.OutgoingData
{
    public class DisplayProjectMap : Profile
    {
        public DisplayProjectMap()
        {
            CreateMap<Domain.Entities.Project, ProjectDto>();
        }
    }
}
