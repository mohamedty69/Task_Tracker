using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
