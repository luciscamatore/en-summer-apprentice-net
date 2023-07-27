using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Exceptions;
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

        public IEnumerable<Event> GetAll()
        {
            return _dbContext.Events.Include(e => e.Venue).Include(e => e.EventType);
        }

        public async Task<Event> GetById(int id)
        {
            var ev = await _dbContext.Events
                .Where(e => e.EventId == id)
                .Include(e => e.Venue)
                .Include(e => e.EventType)
                .FirstOrDefaultAsync();
            if (ev == null) throw new EntityNotFoundException(id, nameof(Event));
            return ev;
        }

        public async Task AddEvent(Event @event)
        {
            _dbContext.Events.Add(@event);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEvent(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEvent(int id)
        {
            _dbContext.Remove(id);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetEventIdByEventName(string eventName)
        {
            var ev = await _dbContext.Events
                .Where(e => e.EventName == eventName)
                .FirstOrDefaultAsync();
            if (ev == null) throw new EntityNotFoundException(ev.EventId, nameof(Event));
            return ev.EventId;
        }
    }
}
