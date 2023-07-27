using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly TicketManagementSystemContext _dbContext;
        public EventRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }
        public int AddEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent(int id)
        {
            _dbContext.Remove(id);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            return _dbContext.Events.Include(e => e.Venue).Include(e => e.EventType);
        }

        public Event GetById(int id)
        {
            return _dbContext.Events
                .Where(e => e.EventId == id)
                .Include(e => e.Venue)
                .Include(e => e.EventType)
                .FirstOrDefault();   
        }

        public void UpdateEvent(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }
    }
}
