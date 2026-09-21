using Domain.SharedEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public Domain.Enums.TaskStatus Status { get; set; } = Domain.Enums.TaskStatus.ToDo;
        public List<Comment> Comments { get; set; }
    }
}
