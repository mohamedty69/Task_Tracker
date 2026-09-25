using Application.Features.Task.Commands;
using Application.Features.Task.Commands.CommandsClasses;
using Application.Features.Task.DTOs;
using Application.Features.Task.Queries.QueryClasses;
using Application.GenericResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Task_Tracker.Middlewares;

namespace Task_Tracker.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ISender _mediatr;

        public TaskController(ISender mediatr)
        {
            _mediatr = mediatr;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskDto taskDto)
        {
            if (taskDto == null)
               throw new NullReferenceException("Tha task must be not empty");
            var check = await _mediatr.Send(new CreateTaskCommand(taskDto));
            if (check.IsSucssed)
                return Created();
            if (check.StatusCode == 400) return BadRequest(check.ErrorMessage);
            else if (check.StatusCode == 403) return Unauthorized(check.ErrorMessage);
            return NotFound(check.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var check = await _mediatr.Send(new DeleteTaskCommand(id));
            if (check.IsSucssed) return Ok("Task is deleted");
            if (check.StatusCode == 400) return BadRequest(check.ErrorMessage);
            else if (check.StatusCode == 403) return Unauthorized(check.ErrorMessage);
            return NotFound(check.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTask(UpdateTaskDto uTaskDto)
        {
            
            if (uTaskDto == null)
                throw new ArgumentNullException("You need to fill the fields");
            var check = await _mediatr.Send(new UpdateTaskCommand(uTaskDto));
            if (check.IsSucssed) return Ok("Task updated successfully");
            if(check.StatusCode == 400) return BadRequest(check.ErrorMessage);
            else if (check.StatusCode == 403) return Unauthorized(check.ErrorMessage);
            return NotFound(check.ErrorMessage);
            
            
        }
        [HttpGet("GetTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var listOfTasks = await _mediatr.Send(new GetTasksQuery());
            return Ok(listOfTasks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var tasks = await _mediatr.Send(new GetByIdTaskQuery(id));
            return Ok(tasks);
        }
        [HttpPut("ChangeTaskStatus")]
        public async Task<IActionResult> ChangeTaskStatus(ChangeTaskStatusDto changeTaskStatusDto)
        {
            if (changeTaskStatusDto == null)
                throw new ArgumentNullException("You need to fill the fields first");
            var result = await _mediatr.Send(new ChangeTaskStatusCommand(changeTaskStatusDto));
            if (result.IsSucssed)
                return Ok("Task Status Updated");
            if (result.StatusCode == 400) return BadRequest(result.ErrorMessage);
            else if (result.StatusCode == 403) return Unauthorized(result.ErrorMessage);
            return NotFound(result.ErrorMessage);
        }
    }
}
