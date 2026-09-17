using Domain.SharedEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Project : BaseEntity
    {
        public List<Task> Tasks { get; set; }
    }
}
