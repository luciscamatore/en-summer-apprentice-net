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
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;
        public OrdersController(IOrdersRepository ordersRepository, IMapper mapper) {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            var orders = _ordersRepository.GetAll();

            var ordersDTO = _mapper.Map<List<OrderDTO>>(orders);

            return Ok(ordersDTO);
        }

        [HttpGet]
        public async Task<ActionResult<Order>> GetByID(int id) 
        { 
            var ord = await _ordersRepository.GetByID(id);

            if(ord == null) return NotFound();

            var ordersDTO = _mapper.Map<OrderDTO>(ord);

            return Ok(ordersDTO);
        }

        [HttpPatch]
        public async Task<ActionResult> Patch(OrdersPatchDTO orderPatchDTO)
        {
            Order ord = await _ordersRepository.GetByID(orderPatchDTO.eventID);
            
            if(ord == null) return NotFound();

            ord.TicketCategory.EventId = orderPatchDTO.eventID;
            ord.TicketCategoryId = orderPatchDTO.ticketCategoryID;
            ord.NumberOfTickets = orderPatchDTO.numberOfTickets;

            await _ordersRepository.UpdateOrders(ord);

            return Ok(ord);
        }

        [HttpDelete] 
        public async Task<ActionResult> Delete(int id)
        {
            var ord = await _ordersRepository.GetByID(id);

            if(ord == null) return NotFound();

            await _ordersRepository.DeleteOrders(ord);

            return NoContent();
        }
    }
}
