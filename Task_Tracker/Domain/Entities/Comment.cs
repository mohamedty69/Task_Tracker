using Domain.SharedEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
