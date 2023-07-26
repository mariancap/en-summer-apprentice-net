using System;
using System.Collections.Generic;

namespace TicketManagementSystemAPI.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int VenueId { get; set; }

    public int EventTypeId { get; set; }

    public string? EventDescription { get; set; }

    public string EventName { get; set; } = null!;

    public DateTime DataStart { get; set; }

    public DateTime DataEnd { get; set; }

    public virtual EventType EventType { get; set; } = null!;

    public virtual ICollection<TicketCategory> TicketCategories { get; set; } = new List<TicketCategory>();

    public virtual Venue Venue { get; set; } = null!;
}
