using AutoMapper;
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

            var ordersDTO = _mapper.Map<OrderDTO>(ord);

            return Ok(ordersDTO);
        }

        [HttpPatch]
        public async Task<ActionResult> PatchOrder(OrdersPatchDTO orderPatchDTO)
        {
            Order ord = await _ordersRepository.GetByID(orderPatchDTO.EventID);

            ord.TicketCategory.EventId = orderPatchDTO.EventID;
            ord.TicketCategoryId = orderPatchDTO.TicketCategoryID;
            ord.NumberOfTickets = orderPatchDTO.NumberOfTickets;

            await _ordersRepository.UpdateOrders(ord);

            return Ok(ord);
        }

        [HttpDelete] 
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var ord = await _ordersRepository.GetByID(id);

            await _ordersRepository.DeleteOrders(ord);

            return NoContent();
        }
    }
}
