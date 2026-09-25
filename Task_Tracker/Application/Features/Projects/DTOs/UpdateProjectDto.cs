using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Projects.DTOs
{
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
