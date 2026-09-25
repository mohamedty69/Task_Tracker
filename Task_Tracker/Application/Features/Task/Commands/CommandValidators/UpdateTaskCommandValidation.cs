using Application.Features.Task.Commands.CommandsClasses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.Commands.CommandValidators
{
    public class UpdateTaskCommandValidation : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidation()
        {
            RuleFor(x => x.updateTaskDto.Title).NotEmpty().MinimumLength(20).MaximumLength(50);
            RuleFor(x => x.updateTaskDto.Description).NotEmpty().MinimumLength(20).MaximumLength(200);
            RuleFor(x => x.updateTaskDto.Id).NotEmpty().GreaterThan(0);
        }

    }
}
