using Domain.SharedEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Task : BaseEntity
    {
        public Project Project { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
