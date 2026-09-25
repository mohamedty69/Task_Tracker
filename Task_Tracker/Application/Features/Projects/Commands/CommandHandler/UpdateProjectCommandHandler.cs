using Application.Features.Projects.Commands.CommandsClasses;
using Application.GenericResponses;
using Application.Interfaces;
using Application.Interfaces.IServices;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Projects.Commands.CommandsHandler
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Results<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public UpdateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<Results<bool>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var existProject = await _unitOfWork.Projects.GetByIdAsync(request.updateProjectDto.Id);
            if (existProject == null)
                return Results<bool>.NotFound("The project does not exist");
            if(existProject.UserId != _currentUserService.UserId) return Results<bool>.Unauthorized("You do not have permission to edit this project.");
            existProject.Name = request.updateProjectDto.Name;
            existProject.Description = request.updateProjectDto.Description;
            var res = _unitOfWork.Projects.Update(existProject);
            if(res)
            {
                await _unitOfWork.SaveChangesAsync();
                return Results<bool>.Success(true);
            }
            return Results<bool>.NotFound("The project does not exist");
        }
    }
}
