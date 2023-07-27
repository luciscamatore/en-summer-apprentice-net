using TicketManagementSystem.Models;

namespace TicketManagementSystem.DTO
{
    public class OrderDTO
    {
        public int orderID { get; set; }

        public string eventName { get; set; }

        public DateTime orderdAt { get; set; }

        public int TicketCategory { get; set; }

        public long totalPrice { get; set; }
    }
}
