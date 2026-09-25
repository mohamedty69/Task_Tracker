using Application.Features.Comment.Commands.CommandClasses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Comment.Commands.CommandValidator
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentValidator()
        {
            RuleFor(x => x.createCommentDto.Content).NotEmpty().MinimumLength(10).MaximumLength(500);
        }
    }
}
