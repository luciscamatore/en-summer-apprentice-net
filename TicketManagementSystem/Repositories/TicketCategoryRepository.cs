using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly TicketManagementSystemContext _dbContext;
        public TicketCategoryRepository() 
        {
            _dbContext = new TicketManagementSystemContext();
        }
        public async Task AddTicketCategory(TicketCategory ticketCategory)
        {
            _dbContext.TicketCategories.Add(ticketCategory);
            await _dbContext.SaveChangesAsync();
        }
    }
}
