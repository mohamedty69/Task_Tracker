using Application.Features.Task.DTOs;
using Application.Features.Task.Queries.QueryClasses;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.Queries.Handlers
{
    public class GetAllTaskQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<TaskDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTaskQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<IEnumerable<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var listOfTasks = await _unitOfWork.Tasks.GetAllAsync();
            var mappedTasks = _mapper.Map<IEnumerable<TaskDto>>(listOfTasks);
            return mappedTasks;
        }
    }
}
