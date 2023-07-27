using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.DTO;
using TicketManagementSystem.Models;
using TicketManagementSystem.Repositories;

namespace TicketManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketCategoryController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public TicketCategoryController(IEventRepository eventRepository, ITicketCategoryRepository ticketCategoryRepository, IMapper mapper, ILogger<TicketCategoryController> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
            _ticketCategoryRepository = ticketCategoryRepository;
        }

        [HttpPost]
        public async Task<ActionResult<TicketCategoryDTO>> PostTicket(TicketCategoryPostDTO ticketCategoryPostDTO)
        {
            var eventId = await _eventRepository.GetEventIdByEventName(ticketCategoryPostDTO.EventName);

            var ticketCategory = new TicketCategory()
            {
                EventId = eventId,
                Description = ticketCategoryPostDTO.Description,
                Price = ticketCategoryPostDTO.Price,
                
            };
            await _ticketCategoryRepository.AddTicketCategory(ticketCategory);

            var tk = _mapper.Map<TicketCategoryDTO>(ticketCategory);

            return Ok(tk);
        }
    }
}
