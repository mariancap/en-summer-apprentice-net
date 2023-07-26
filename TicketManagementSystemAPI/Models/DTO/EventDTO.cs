namespace TicketManagementSystemAPI.Models.DTO
{
    public class EventDTO
    {
        public int EventID { get; set; }

        public string EventName { get; set; } = string.Empty;

        public string EventDescription { get; set; } = string.Empty;    
        public string EventType { get; set; } = string.Empty;

        public string Venue { get; set; } = string.Empty;

    }
}
