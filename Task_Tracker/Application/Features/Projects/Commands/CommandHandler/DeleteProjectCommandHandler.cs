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
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Results<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public DeleteProjectCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }
        public async Task<Results<bool>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(request.id);
            if (project != null)
            {
                if(project.UserId == _currentUserService.UserId)
                {
                    var result = await _unitOfWork.Projects.DeleteAsync(request.id);
                    return Results<bool>.Unauthorized("You do not have permission to delete this project."); ;
                }
            }
            return Results<bool>.NotFound("The project does not exist");
        }
    }
}
