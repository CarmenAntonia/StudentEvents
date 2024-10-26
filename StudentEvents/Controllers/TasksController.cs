using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentEvents.Dtos;
using StudentEvents.Services;

namespace StudentEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        TaskService taskService;

        public TasksController(TaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public Task<List<Models.Task>> Get()
        {
            return taskService.GetAsync();
        }

        [HttpGet]
        [Route("task")]
        public async Task<ActionResult<Models.Task>> GetbyId(string id)
        {
            var task = await taskService.GetAsync(id);
            if (task is null)
            {
                return NotFound();
            }
            return task;
        }
       

        [HttpPost]
        public async Task<IActionResult> Post(TaskDto task)
        {
            await taskService.CreateAsync(task);
            return CreatedAtAction(nameof(Get), task);
        }
    }
}
