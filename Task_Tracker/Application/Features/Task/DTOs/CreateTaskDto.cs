using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application.Features.Task.DTOs
{
    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
