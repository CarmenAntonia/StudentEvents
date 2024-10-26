using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentEvents.Dtos;
using StudentEvents.Models;
using StudentEvents.Services;

namespace StudentEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
         EventService eventService;

        public EventsController(EventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public Task<List<Event>> Get()
        {
            return eventService.GetAsync();
        }

        [HttpGet]
        [Route("event")]
        public async Task<ActionResult<Event>> GetbyId(string id)
        {
            var _event = await eventService.GetAsync(id);
            if (_event is null)
            {
                return NotFound();
            }
            return _event;
        }


        [HttpPost]
        public async Task<IActionResult> Post(EventDto _event)
        {
            await eventService.CreateAsync(_event);
            return CreatedAtAction(nameof(Get), _event);
        }
    }
}

