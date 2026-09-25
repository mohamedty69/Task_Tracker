using Application.Features.Comment.Commands.CommandClasses;
using Application.GenericResponses;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Comment.Commands.CommandHandlers
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, Results<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Results<bool>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(request.createCommentDto.TaskId);
            if(task ==null)
                return Results<bool>.NotFound("The task does not exist to make a comment on it");
            var mappedComment = _mapper.Map<Domain.Entities.Comment>(request.createCommentDto);
            await _unitOfWork.Comments.AddAsync(mappedComment);
            await _unitOfWork.SaveChangesAsync();
            return Results<bool>.Success(true);
        }
    }
}
