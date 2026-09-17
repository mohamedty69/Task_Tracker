using Domain.SharedEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Comment : BaseEntity
    {
        public Task Task { get; set; }
    }
}
