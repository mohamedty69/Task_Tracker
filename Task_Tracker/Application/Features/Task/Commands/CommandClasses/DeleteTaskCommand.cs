using Application.GenericResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.Commands
{
    public record DeleteTaskCommand(int id) : IRequest<Results<bool>>;
}
