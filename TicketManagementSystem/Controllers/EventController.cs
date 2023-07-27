using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.DTO;
using TicketManagementSystem.Models;
using TicketManagementSystem.Repositories;

namespace TicketManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public EventController(IEventRepository eventRepository, IMapper mapper, ILogger<EventController> logger) {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async  Task<ActionResult<List<Event>>> getAllEvents()
        {
            var ev = await _eventRepository.GetAll();

            var eventDTO = _mapper.Map<List<EventDTO>>(ev);

            return Ok(eventDTO);
        }
        [HttpGet]
        public ActionResult<Event> getEventsByID(int id) { 
                
            Event ev = _eventRepository.GetById(id);

            if(ev == null) return NotFound();

            var eventDTO = _mapper.Map<EventDTO>(ev);

            return Ok(eventDTO);
        }

        [HttpPatch]
        public ActionResult<EventPatchDTO> Patch(EventPatchDTO eventPatch)
        {
            var ev = _eventRepository.GetById(eventPatch.eventId);

            if(ev == null) return NotFound();

            //var e = _mapper.Map<Event>(eventPatch);
            
            ev.EventName = eventPatch.eventName;
            ev.EventId = eventPatch.eventId;
            ev.EventDescription = eventPatch.eventDescription;

            _eventRepository.UpdateEvent(ev);

            return Ok(ev);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var ev = _eventRepository.GetById(id);

            if (ev == null) return NotFound();

            _eventRepository.DeleteEvent(id);

            return NoContent();
        }
    }
}
