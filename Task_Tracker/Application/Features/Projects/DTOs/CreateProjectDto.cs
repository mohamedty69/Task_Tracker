using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Projects.DTOs
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
