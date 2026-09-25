using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Comment.Dto
{
    public class CreateCommentDto
    {
        public int TaskId { get; set; }
        public string Content {  get; set; }

    }
}
