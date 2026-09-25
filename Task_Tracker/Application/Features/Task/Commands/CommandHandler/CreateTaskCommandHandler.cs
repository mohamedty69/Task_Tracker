using Application.Features.Task.Commands.CommandsClasses;
using Application.GenericResponses;
using Application.Interfaces;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.Commands.CommandHandler
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Results<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<Results<bool>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<Domain.Entities.Task>(request.createTaskDto);
            if (task == null)
                return Results<bool>.NotFound("The task does not exist");
            var project = await _unitOfWork.Projects.GetByIdAsync(request.createTaskDto.ProjectId);
            if (project == null)
                return Results<bool>.NotFound("The project does not exist");
            if(project.UserId != _currentUserService.UserId) return Results<bool>.Unauthorized("You do not have permission to make a task to this project."); ; 
            await _unitOfWork.Tasks.AddAsync(task);
            await _unitOfWork.SaveChangesAsync();
            return Results<bool>.Success(true);
        }
    }
}
