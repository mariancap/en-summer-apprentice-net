using TicketManagementSystemAPI.Models;

namespace TicketManagementSystemAPI.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Task<Event> GetById(int id);
        int Add(Event @event);

        void Update(Event @event);

        void delete(Event @event);
    }
}
