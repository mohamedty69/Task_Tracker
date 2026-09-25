using Application.Features.Task.Commands.CommandsClasses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.Commands.CommandValidators
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(x => x.createTaskDto.Title).NotEmpty().MinimumLength(20).MaximumLength(50);
            RuleFor(x => x.createTaskDto.Description).NotEmpty().MinimumLength(20).MaximumLength(200);
        }
    }
}
