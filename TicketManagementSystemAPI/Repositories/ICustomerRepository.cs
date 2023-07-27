using TicketManagementSystemAPI.Models;

namespace TicketManagementSystemAPI.Repositories
{
    public interface ICustomerRepository
    {

        Task<Customer> GetById(int id);
    }
}
