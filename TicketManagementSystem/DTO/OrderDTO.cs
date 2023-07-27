namespace TicketManagementSystem.DTO
{
    public class OrderDTO
    {
        public string EventName { get; set; }

        public string Location { get; set; }

        public long TotalPrice { get; set; }

        public long NumberOfTickets { get; set; }

        public DateTime OrderdAt { get; set; }

        public string TicketCategory { get; set; }
    }
}
