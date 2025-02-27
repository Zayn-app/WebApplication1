
using System.Collections.Generic;

using WebApplication1.Models.Entity;

namespace WebApplication1.Data.Services
{
    public interface IEventsService
    {
        Task<IEnumerable<Event>>GetAllAsync();

        Task<Event> GetByIdAsync(int id);

        Task AddAsync(Event @event);

        Task<Event> UpdateAsync(int id, Event newEvent);
        Task DeleteAsync(int id);
        Task<Event>GetById(int id);
    }
}
