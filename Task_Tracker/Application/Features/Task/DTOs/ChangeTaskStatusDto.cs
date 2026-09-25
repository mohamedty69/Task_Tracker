using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Task.DTOs
{
    public class ChangeTaskStatusDto
    {
        public int TaskId { get; set; }
        public Domain.Enums.TaskStatus Status { get; set; }
    }
}
