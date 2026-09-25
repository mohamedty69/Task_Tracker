using Application.Features.Auth.Commands.CommandClasses;
using Application.GenericResponses;
using Application.Interfaces.IServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Auth.Commands.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Results<string>>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(IIdentityService identityService, IJwtService jwtService)
        {
            _identityService = identityService;
            _jwtService = jwtService;
        }

        public async Task<Results<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _identityService.Login(request.loginDto);
            if (user == null)
                return Results<string>.NotFound("The user does not exist");
            var jwtToken = _jwtService.CreateTokenForUser(user);
            return Results<string>.Success(jwtToken);
        }
    }
}
