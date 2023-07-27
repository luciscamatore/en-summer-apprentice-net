using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.DTO;
using TicketManagementSystem.Exceptions;
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
        public ActionResult<List<Event>> GetAllEvents()
        {
            var ev = _eventRepository.GetAll();

            var eventDTO = _mapper.Map<List<EventDTO>>(ev);

            return Ok(eventDTO);
        }
        [HttpGet]
        public async Task<ActionResult<Event>> GetEventsByID(int id) { 
                
            Event ev = await _eventRepository.GetById(id);

            var eventDTO = _mapper.Map<EventDTO>(ev);

            return Ok(eventDTO);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDTO>> PatchEvent(EventPatchDTO eventPatch)
        {
            var ev = await _eventRepository.GetById(eventPatch.EventId);
            
            ev.EventName = eventPatch.EventName;
            ev.EventId = eventPatch.EventId;
            ev.EventDescription = eventPatch.EventDescription;

            await _eventRepository.UpdateEvent(ev);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            var ev = await _eventRepository.GetById(id) ?? throw new EntityNotFoundException(id, nameof(Event));
            await _eventRepository.DeleteEvent(id);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Event>> AddEvent(EventAddDTO eventAddDTO)
        {
            var ev = _mapper.Map<Event>(eventAddDTO);

            await _eventRepository.AddEvent(ev);

            return Ok(ev);
        }
    }
}
