using Application.Features.Auth.Dto;
using Application.GenericResponses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Auth.Commands.CommandClasses
{
    public record RegisterCommand(RegisterDto registerDto) : IRequest<Results<bool>>;
}
