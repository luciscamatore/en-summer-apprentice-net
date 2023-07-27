using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> GetAll();
        Order GetByID(int id);
        void UpdateOrders(Order ord);

        void DeleteOrders(Order order);
    }
}
