using System;
using System.Collections.Generic;

namespace TicketManagementSystemAPI.Models;

public partial class Venue
{
    public int VenueId { get; set; }

    public string? EventLocation { get; set; }

    public string VenueType { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
