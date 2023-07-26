using AutoMapper;
using TicketManagementSystemAPI.Models;
using TicketManagementSystemAPI.Models.DTO;

namespace TicketManagementSystemAPI.Profiles
{
    public class OrderProfile : Profile
    {

        public OrderProfile() { 
            CreateMap<Order,OrderDTO>().ReverseMap();
            CreateMap<Order,OrderPatchDTO>().ReverseMap();

        
        }
    }
}
