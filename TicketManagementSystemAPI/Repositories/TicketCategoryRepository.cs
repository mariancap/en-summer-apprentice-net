using Microsoft.EntityFrameworkCore;
using TicketManagementSystemAPI.Exceptions;
using TicketManagementSystemAPI.Models;

namespace TicketManagementSystemAPI.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {

        private readonly PracticaContext _dbContext;

        public TicketCategoryRepository(PracticaContext practicaContext)
        {
              _dbContext = practicaContext; 
        }

        public int Add(TicketCategory ticketCategory)
        {
            throw new NotImplementedException();
        }

        public void Delete(TicketCategory ticketCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TicketCategory>> GetAllAsync()
        {
            var ticketCategories = await _dbContext.TicketCategories.ToListAsync();
            return ticketCategories;
        }

        public async Task<TicketCategory> GetById(int id)
        {
           

            var @ticketCategory = await _dbContext.TicketCategories.Where(e => e.TicketCategoryId == id).FirstOrDefaultAsync();
            if (@ticketCategory == null)
            {
                throw new EntityNotFoundException(id, nameof(TicketCategory));
            }
            return @ticketCategory;


        }

        public Task<TicketCategory> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public bool TicketCategoryExists(long ticketCategoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TicketCategory ticketCategory)
        {
            throw new NotImplementedException();
        }
    }
}
