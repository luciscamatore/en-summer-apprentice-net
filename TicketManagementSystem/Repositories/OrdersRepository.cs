using Microsoft.EntityFrameworkCore;
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

        public Order GetByID(int id) 
        {
            return _dbContext.Orders
                .Where(o => o.OrderId == id)
                .Include(e => e.TicketCategory)
                .FirstOrDefault();
        }

        public void UpdateOrders(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        public void DeleteOrders(Order order) 
        {
            _dbContext.Remove(order);
            _dbContext.SaveChanges();
        }

    }   
}
