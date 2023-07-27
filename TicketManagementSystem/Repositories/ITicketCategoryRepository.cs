using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public interface ITicketCategoryRepository
    {
        Task AddTicketCategory(TicketCategory ticketCategory);
    }
}
