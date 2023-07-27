using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Exceptions;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly TicketManagementSystemContext _dbContext;
        public OrdersRepository() { _dbContext = new TicketManagementSystemContext(); }
       
        public IEnumerable<Order> GetAll()
        {
            var ord = _dbContext.Orders
                .Include(e => e.TicketCategory)
                .Include(e => e.TicketCategory.Event);
            return ord;
        }

        public async Task<Order> GetByID(int id) 
        {
            var ev = await _dbContext.Orders
                .Where(o => o.OrderId == id)
                .Include(e => e.TicketCategory)
                .ThenInclude(e => e.Event)
                .ThenInclude(e => e.Venue)
                .FirstOrDefaultAsync();
            if (ev == null) throw new EntityNotFoundException(id, nameof(Order));
            return ev;
        }

        public async Task UpdateOrders(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrders(Order order) 
        {
            _dbContext.Remove(order);
            await _dbContext.SaveChangesAsync();
        }

    }   
}
