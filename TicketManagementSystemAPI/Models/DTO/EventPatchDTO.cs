﻿namespace TicketManagementSystemAPI.Models.DTO
{
    public class EventPatchDTO
    {
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string EventDescription { get; set; } 
    }
}
