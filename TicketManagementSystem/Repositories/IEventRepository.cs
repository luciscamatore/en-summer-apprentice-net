using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Task<Event> GetById(int id);
        int AddEvent(Event @event);
        Task UpdateEvent(Event @event);
        Task DeleteEvent(int id);
    }
}
