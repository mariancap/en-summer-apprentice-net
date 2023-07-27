using Microsoft.EntityFrameworkCore;
using TicketManagementSystemAPI.Exceptions;
using TicketManagementSystemAPI.Models;

namespace TicketManagementSystemAPI.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly PracticaContext _dbContext;
        public EventRepository()
        {
            _dbContext = new PracticaContext();
        }
        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

        public void delete(Event @event)
        {
           _dbContext.Remove(@event);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events.Include(x=>x.EventType).Include(x=>x.Venue).ToList();
            return events;
        }

        public async Task<Event> GetById(int id)
        {

            var @event = await _dbContext.Events.Where(e => e.EventId == id)
                .Include(e => e.EventType)
                .Include(e => e.Venue)
            .FirstOrDefaultAsync();

            if (@event == null) {
                throw new EntityNotFoundException(id,nameof(Event));
            }
            
            return @event;
        }

        public void Update(Event @event)
        {
            _dbContext.Entry(@event).State= EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
