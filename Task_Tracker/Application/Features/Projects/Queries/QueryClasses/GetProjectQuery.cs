using Application.Features.Projects.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Projects.Queries.QueryClasses
{
    public record GetProjectQuery(int id) : IRequest<ProjectDto>;
    
}
