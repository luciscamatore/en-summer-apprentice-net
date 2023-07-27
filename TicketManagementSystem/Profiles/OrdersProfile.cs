using AutoMapper;
using TicketManagementSystem.DTO;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile() 
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.TicketCategory, opt => opt.MapFrom(src => src.TicketCategory.Description))
                .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.TicketCategory.Event.EventName))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.TicketCategory.Event.Venue.Location))
                .ReverseMap();

            CreateMap<Order, OrdersPatchDTO>();
        }
    }
}
