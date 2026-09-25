using Application.Features.Auth.Dto;
using Application.GenericResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Auth.Commands.CommandClasses
{
    public record LoginCommand(LoginDto loginDto) : IRequest<Results<string>>; 

}
