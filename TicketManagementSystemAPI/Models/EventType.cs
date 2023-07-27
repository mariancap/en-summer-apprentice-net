using System;
using System.Collections.Generic;

namespace TicketManagementSystemAPI.Models;

public partial class EventType
{
    public int EventTypeId { get; set; }

    public string EventTypeName { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public override string ToString()
    {
        return EventTypeName;
    }
}
