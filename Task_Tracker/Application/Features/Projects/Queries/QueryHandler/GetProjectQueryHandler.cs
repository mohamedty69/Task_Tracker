using Application.Features.Projects.DTOs;
using Application.Features.Projects.Queries.QueryClasses;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Projects.Queries.QueryHandler
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProjectQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProjectDto> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(request.id);
            var mappedProject = _mapper.Map<ProjectDto>(project);
            return mappedProject;
        }
    }
}
