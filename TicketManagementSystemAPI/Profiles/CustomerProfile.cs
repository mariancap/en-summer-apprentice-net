using AutoMapper;
using TicketManagementSystemAPI.Models;
using TicketManagementSystemAPI.Models.DTO;

namespace TicketManagementSystemAPI.Profiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
