using System;
using System.Collections.Generic;

namespace TicketManagementSystemAPI.Models;

public partial class TotalNumberOfTicketsPerCategory
{
    public int TicketCategoryId { get; set; }

    public int? TotalPriceSold { get; set; }

    public int? TotalOfTicketsSold { get; set; }
}
