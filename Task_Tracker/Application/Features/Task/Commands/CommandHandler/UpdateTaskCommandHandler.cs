using Application.Features.Task.Commands.CommandsClasses;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.Commands.CommandHandler
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var existTask = await _unitOfWork.Tasks.GetByIdAsync(request.updateTaskDto.Id);
            if(request.updateTaskDto.Title != existTask.Title || request.updateTaskDto.Description != existTask.Description)
            {
                var mappedTask = _mapper.Map<Domain.Entities.Task>(request.updateTaskDto);
                _unitOfWork.Tasks.Update(mappedTask);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
