using AutoMapper;
using TicketManagementSystemAPI.Models;
using TicketManagementSystemAPI.Models.DTO;

namespace TicketManagementSystemAPI.Profiles
{
    public class EventProfile : Profile
    {

        public EventProfile()
        {
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<Event, EventPatchDTO>().ReverseMap();
        }
    }
}
