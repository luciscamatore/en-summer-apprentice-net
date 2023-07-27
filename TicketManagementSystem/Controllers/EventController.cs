﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        public ActionResult<List<Event>> getAllEvents()
        {
            var ev = _eventRepository.GetAll();

            var eventDTO = _mapper.Map<List<EventDTO>>(ev);

            return Ok(eventDTO);
        }
        [HttpGet]
        public async Task<ActionResult<Event>> getEventsByID(int id) { 
                
            Event ev = await _eventRepository.GetById(id);

            var eventDTO = _mapper.Map<EventDTO>(ev);

            return Ok(eventDTO);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDTO>> Patch(EventPatchDTO eventPatch)
        {
            var ev = await _eventRepository.GetById(eventPatch.EventId);

            //var e = _mapper.Map<Event>(eventPatch);
            
            ev.EventName = eventPatch.EventName;
            ev.EventId = eventPatch.EventId;
            ev.EventDescription = eventPatch.EventDescription;

            _eventRepository.UpdateEvent(ev);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var ev = _eventRepository.GetById(id);

            _eventRepository.DeleteEvent(id);

            return NoContent();
        }

       
    }
}
