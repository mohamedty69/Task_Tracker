using Application.Features.Projects.Commands.CommandsClasses;
using Application.Features.Projects.DTOs;
using Application.Features.Projects.Queries.QueryClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Task_Tracker.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ISender _mediatr;

        public ProjectController(ISender mediatr)
        {
            _mediatr = mediatr;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _mediatr.Send(new GetProjectQuery(id));
            if(project == null) 
                return NotFound();
            return Ok(project);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectDto createProjectDto)
        {
            var check = await _mediatr.Send(new CreateProjectCommand(createProjectDto));
            if (check) return Created();
            return BadRequest();
        }
    }
}
