using Microsoft.Identity.Client;

namespace TicketManagementSystemAPI.Models.DTO
{
    public class OrderPatchDTO
    {
        public int orderID { get; set; }
        
        public int customer_id { get; set; }

        public int ticket_category_id { get; set; }
        public int number_of_tickets { get; set; } 

    }
}
