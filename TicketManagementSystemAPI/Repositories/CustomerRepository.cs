using Microsoft.EntityFrameworkCore;
using TicketManagementSystemAPI.Exceptions;
using TicketManagementSystemAPI.Models;

namespace TicketManagementSystemAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        public readonly PracticaContext _dbContext;

        public CustomerRepository(PracticaContext practicaContext)
        {
            _dbContext = practicaContext;
        }
        public async Task<Customer> GetById(int id)
        {
            var @customer = await _dbContext.Customers.Where(c => c.CustomerId == id).FirstOrDefaultAsync();

            if (customer == null)
            {
                throw new EntityNotFoundException(id, nameof(customer));
            }

            return customer;
        }
    }
}
