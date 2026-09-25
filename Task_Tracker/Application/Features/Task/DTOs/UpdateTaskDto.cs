using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.DTOs
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Domain.Enums.TaskStatus TaskStatus { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
