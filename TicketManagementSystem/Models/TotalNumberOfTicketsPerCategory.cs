﻿using System;
using System.Collections.Generic;

namespace TicketManagementSystem.Models;

public partial class TotalNumberOfTicketsPerCategory
{
    public int? TicketCategoryId { get; set; }

    public int? SumaBilete { get; set; }

    public int? ValoareVanzari { get; set; }
}
