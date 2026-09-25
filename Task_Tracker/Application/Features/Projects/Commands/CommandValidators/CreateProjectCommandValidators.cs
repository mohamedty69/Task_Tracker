using Application.Features.Projects.Commands.CommandsClasses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Projects.Commands.CommandValidators
{
    public class CreateProjectCommandValidators : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidators()
        {
            RuleFor(x => x.createProjectDto.Name).NotEmpty().WithMessage("The project name can not be empty");
            RuleFor(x => x.createProjectDto.Description).NotEmpty().MinimumLength(20).MaximumLength(200);
        }
    }
}
