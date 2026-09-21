using Application.Features.Task.DTOs;
using Application.Features.Task.Queries.QueryClasses;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.Queries.QueryHandlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetByIdTaskQuery, TaskDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TaskDto> Handle(GetByIdTaskQuery request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(request.id);
            var mappedTask = _mapper.Map<TaskDto>(task);
            return mappedTask;
        }
    }
}
