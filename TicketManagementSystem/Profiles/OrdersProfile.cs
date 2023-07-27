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
                .ForMember(dest => dest.TicketCategory, opt => opt.MapFrom(src => src.TicketCategory.TicketCategoryId))
                .ForMember(dest => dest.eventName, opt => opt.MapFrom(src => src.TicketCategory.Event.EventName))
                .ReverseMap();

            CreateMap<Order, OrdersPatchDTO>();
        }
    }
}
