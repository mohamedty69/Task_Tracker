using Application.Features.Projects.DTOs;
using Application.GenericResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Projects.Commands.CommandsClasses
{
    public record CreateProjectCommand(CreateProjectDto createProjectDto) : IRequest<Results<bool>>;
}
