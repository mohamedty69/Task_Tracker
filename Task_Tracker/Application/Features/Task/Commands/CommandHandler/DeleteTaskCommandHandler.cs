using Application.GenericResponses;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.Commands.CommandHandler
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Results<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Results<bool>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var check = await _unitOfWork.Tasks.DeleteAsync(request.id);
            await _unitOfWork.SaveChangesAsync();
            if (check)
                return Results<bool>.Success(true);
            return Results<bool>.Failure("The task does not deleted perhapes can not be found or antoher issue");
        }
    }
}
