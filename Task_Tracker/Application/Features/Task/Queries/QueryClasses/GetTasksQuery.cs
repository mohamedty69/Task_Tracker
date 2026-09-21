using Application.Features.Task.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.Queries.QueryClasses
{
    public record GetTasksQuery () : IRequest<IEnumerable<TaskDto>>;    
}
