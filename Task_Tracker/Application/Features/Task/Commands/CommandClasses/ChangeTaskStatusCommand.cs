using Application.Features.Task.DTOs;
using Application.GenericResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.Commands.CommandsClasses
{
    public record ChangeTaskStatusCommand(ChangeTaskStatusDto changeTaskStatusDto) : IRequest<Results<bool>>;
}
