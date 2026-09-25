using Application.Features.Task.Commands.CommandsClasses;
using Application.GenericResponses;
using Application.Interfaces;
using MediatR;


namespace Application.Features.Task.Commands.CommandHandler
{
    public class ChangeTaskStatusHandler : IRequestHandler<ChangeTaskStatusCommand, Results<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeTaskStatusHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Results<bool>> Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(request.changeTaskStatusDto.TaskId);
            if (task == null) 
                return Results<bool>.Failure("Invalid changes for task status");
            if (task.Status == Domain.Enums.TaskStatus.Completed 
                || task.Status == Domain.Enums.TaskStatus.Cancelled)
                return Results<bool>.Failure("Invalid changes for task status"); 
            if (task.Status == Domain.Enums.TaskStatus.ToDo && request.changeTaskStatusDto.Status == Domain.Enums.TaskStatus.Completed)
                return Results<bool>.Failure("Invalid changes for task status");
            else if (task.Status == Domain.Enums.TaskStatus.InProgress && request.changeTaskStatusDto.Status == Domain.Enums.TaskStatus.ToDo)
                return Results<bool>.Failure("Invalid changes for task status");
            task.Status = request.changeTaskStatusDto.Status;
            _unitOfWork.Tasks.Update(task);
            await _unitOfWork.SaveChangesAsync();
            return Results<bool>.Success(true);
        }
    }
}
