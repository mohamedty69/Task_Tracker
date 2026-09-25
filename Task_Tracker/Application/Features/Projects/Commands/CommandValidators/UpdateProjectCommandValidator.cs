using Application.Features.Projects.Commands.CommandsClasses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Projects.Commands.CommandValidators
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(x => x.updateProjectDto.Name).NotEmpty().WithMessage("The project name can not be empty");
            RuleFor(x => x.updateProjectDto.Description).NotEmpty().MinimumLength(20).MaximumLength(200);
            RuleFor(x => x.updateProjectDto.Id).NotEmpty().GreaterThan(0);

        }

    }
}
