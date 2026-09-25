using Application.Features.Projects.DTOs;
using Application.GenericResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Projects.Commands.CommandsClasses
{
    public record UpdateProjectCommand(UpdateProjectDto updateProjectDto) : IRequest<Results<bool>>;
}
