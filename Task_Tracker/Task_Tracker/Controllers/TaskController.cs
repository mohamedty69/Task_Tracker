using Application.Features.Task.Commands;
using Application.Features.Task.Commands.CommandsClasses;
using Application.Features.Task.DTOs;
using Application.Features.Task.Queries.QueryClasses;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Task_Tracker.Controllers
{
    [Route("[controller]")]
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
            if (check)
                return Created();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var check = await _mediatr.Send(new DeleteTaskCommand(id));
            if (check) return Ok("Task is deleted");
            return BadRequest("The task can not be found");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTask(UpdateTaskDto uTaskDto)
        {
            if (uTaskDto == null)
                throw new ArgumentNullException("You need to fill the fields");
            var check = await _mediatr.Send(new UpdateTaskCommand(uTaskDto));
            if (check) return Ok("Task updated successfully");
            return BadRequest("You need to fill or change the fields value to update");
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
    }
}
