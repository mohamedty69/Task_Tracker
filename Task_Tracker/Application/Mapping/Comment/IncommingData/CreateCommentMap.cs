using Application.Features.Comment.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mapping.Comment.IncommingData
{
    public class CreateCommentMap : Profile
    {
        public CreateCommentMap()
        {
            CreateMap<CreateCommentDto, Domain.Entities.Comment>();
        }
    }
}
