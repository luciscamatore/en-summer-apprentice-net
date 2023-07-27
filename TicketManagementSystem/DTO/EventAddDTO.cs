using TicketManagementSystem.Models;

namespace TicketManagementSystem.DTO
{
    public class EventAddDTO
    {
        public int VenueId { get; set; }
        public int EventTypeId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TicketCategoryPostDTO TicketCategoriesVIP { get; set; }
        public TicketCategoryPostDTO TicketCategoriesStandard { get; set; }
    }
}
