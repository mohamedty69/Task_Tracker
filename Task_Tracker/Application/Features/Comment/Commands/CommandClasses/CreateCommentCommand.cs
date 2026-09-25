using Application.Features.Comment.Dto;
using Application.GenericResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Comment.Commands.CommandClasses
{
    public record CreateCommentCommand(CreateCommentDto createCommentDto) : IRequest<Results<bool>>;
    
   
}
