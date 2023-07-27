using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Event GetById(int id);
        int AddEvent(Event @event);
        void UpdateEvent(Event @event);
        void DeleteEvent(int id);
    }
}
