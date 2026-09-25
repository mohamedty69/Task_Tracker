using Application.Features.Auth.Commands.CommandClasses;
using Application.GenericResponses;
using Application.Interfaces.IServices;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Auth.Commands.CommandHandlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Results<bool>>
    {
        private readonly IIdentityService _identityService;

        public RegisterCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Results<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.RegisterUser(request.registerDto);
            if (result.Succeeded) return Results<bool>.Success(true);
            var errors = "";
            foreach(var error in result.Errors)
            {
                errors += error.Description;
                errors += "\n";
            }
            return Results<bool>.Failure($"Fail to register user duo to: {errors}");
        }
    }
}
