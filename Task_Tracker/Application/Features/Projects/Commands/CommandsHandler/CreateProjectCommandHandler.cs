using Application.Features.Projects.Commands.CommandsClasses;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Projects.Commands.CommandsHandler
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand,bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if (request.createProjectDto == null) throw new ArgumentNullException("You need to fill the fields with values");
            var mappedProject = _mapper.Map<Domain.Entities.Project>(request.createProjectDto);
            await _unitOfWork.Projects.AddAsync(mappedProject);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
