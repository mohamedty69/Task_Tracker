using Domain.SharedEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
