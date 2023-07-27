using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> GetAll();
        Task<Order> GetByID(int id);
        Task UpdateOrders(Order ord);

        Task DeleteOrders(Order order);
    }
}
