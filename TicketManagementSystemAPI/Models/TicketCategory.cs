using System;
using System.Collections.Generic;

namespace TicketManagementSystemAPI.Models;

public partial class TicketCategory
{
    public int TicketCategoryId { get; set; }

    public int EventId { get; set; }

    public string? TicketDescription { get; set; }

    public int Price { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
