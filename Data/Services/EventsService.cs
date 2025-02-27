using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entity;

namespace WebApplication1.Data.Services
{
    public class EventsService : IEventsService
    {

        private readonly Context _context;
        public EventsService(Context context)
        {
            _context = context;
        }
        public async Task AddAsync(Event @event)
        {
            await _context.Events.AddAsync(@event);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Events.FirstOrDefaultAsync(n => n.EventId == id);
            _context.Events.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            var result = await _context.Events.ToListAsync();
            return result;
        }

        public async Task<Event> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            var result = await _context.Events.FirstOrDefaultAsync(n=>n.EventId==id);
            return result;
        }

        public async Task<Event> UpdateAsync(int id, Event newEvent)
        {
            _context.Update(newEvent);
            await _context.SaveChangesAsync();
            return newEvent;
        }

       
    }
}
