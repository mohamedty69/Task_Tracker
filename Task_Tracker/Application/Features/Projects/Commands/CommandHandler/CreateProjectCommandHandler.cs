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
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand,Results<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Results<bool>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if (request.createProjectDto == null) Results<bool>.Failure("You need to fill the fields with values");
            var mappedProject = _mapper.Map<Domain.Entities.Project>(request.createProjectDto);
            mappedProject.UserId = _currentUserService.UserId;
            await _unitOfWork.Projects.AddAsync(mappedProject);
            await _unitOfWork.SaveChangesAsync();
            return Results<bool>.Success(true);
        }
    }
}
