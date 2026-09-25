using Application.Features.Auth.Commands.CommandClasses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Auth.Commands.CommandValidation
{
    public class RegisterUserCommandValidation : AbstractValidator<RegisterCommand>
    {
        public RegisterUserCommandValidation()
        {
            RuleFor(x => x.registerDto.FirstName).NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.registerDto.LastName).NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.registerDto.UserName).NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.registerDto.Email).NotEmpty().EmailAddress().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.registerDto.Password).NotEmpty().MinimumLength(8)
                .Matches("[A-Z]").Matches("[0-9]").Matches("[a-z]").
                Matches("[^A-Za-z0-9]").WithMessage("Must contain a special character");
            RuleFor(x => x.registerDto.PhoneNumber).NotEmpty().Matches("^[0-9]*$").WithMessage("Phone number must contains only numbers").MaximumLength(11);
        }
    }
}
