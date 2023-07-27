using System;
using System.Collections.Generic;

namespace TicketManagementSystem.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int TicketCategoryId { get; set; }

    public DateTime OrderdAt { get; set; }

    public long NumberOfTickets { get; set; }

    public long TotalPrice { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual TicketCategory? TicketCategory { get; set; }
}
