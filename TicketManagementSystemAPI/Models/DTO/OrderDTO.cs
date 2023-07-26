namespace TicketManagementSystemAPI.Models.DTO
{
    public class OrderDTO
    {

        public int orderID {get; set;}
        public int customer_id { get; set;}

        public int ticket_category_id { get; set;}

        public DateTime ordered_at { get; set;}
        public int totalPrice { get; set;}

    }
}
