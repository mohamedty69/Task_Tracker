using Application.Features.Task.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.Commands.CommandsClasses
{
    public record UpdateTaskCommand(UpdateTaskDto updateTaskDto ) : IRequest<bool>;
}
