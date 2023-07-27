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
        public int AddEvent(Event @event)
        {
            throw new NotImplementedException();
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

        public async Task UpdateEvent(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;

            _dbContext.SaveChangesAsync();
        }
        public async Task DeleteEvent(int id)
        {
            _dbContext.Remove(id);
            _dbContext.SaveChangesAsync();
        }
    }
}
