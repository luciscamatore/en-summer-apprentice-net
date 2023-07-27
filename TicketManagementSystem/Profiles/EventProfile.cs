using AutoMapper;
using TicketManagementSystem.DTO;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile() {
            CreateMap<Event, EventDTO>()
                .ForMember(dest => dest.Venue, opt => opt.MapFrom(src => src.Venue.Location))
                .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType.EventTypeName))
                .ReverseMap();

            CreateMap<Event, EventPatchDTO>().ReverseMap();
            CreateMap<Task<Event>, EventDTO>().ReverseMap();

            CreateMap<Event, EventAddDTO>().ReverseMap();
        }
    }
}
