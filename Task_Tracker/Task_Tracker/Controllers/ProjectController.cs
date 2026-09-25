using Application.Features.Projects.Commands.CommandsClasses;
using Application.Features.Projects.DTOs;
using Application.Features.Projects.Queries.QueryClasses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Task_Tracker.Controllers
{
    [Route("[Controller]")]
    [Authorize]
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
        [HttpPost("CreateProject")]
        public async Task<IActionResult> CreateProject(CreateProjectDto createProjectDto)
        {
            var check = await _mediatr.Send(new CreateProjectCommand(createProjectDto));
            if (check.IsSucssed) return Created();
            if (check.StatusCode == 400) return BadRequest(check.ErrorMessage);
            else if (check.StatusCode == 403) return Unauthorized(check.ErrorMessage);
            return NotFound(check.ErrorMessage);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto updateProjectDto)
        {
            var result = await _mediatr.Send(new UpdateProjectCommand(updateProjectDto));
            if (result.IsSucssed)
                return Ok("Project successfully Updated");
            if (result.StatusCode == 400) return BadRequest(result.ErrorMessage);
            else if (result.StatusCode == 403) return Unauthorized(result.ErrorMessage);
            return NotFound(result.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _mediatr.Send(new DeleteProjectCommand(id));
            if (result.IsSucssed)
                return Ok("Project Deleted Successfully");
            if (result.StatusCode == 400) return BadRequest(result.ErrorMessage);
            else if (result.StatusCode == 403) return Unauthorized(result.ErrorMessage);
            return NotFound(result.ErrorMessage);
        }
    }
}
