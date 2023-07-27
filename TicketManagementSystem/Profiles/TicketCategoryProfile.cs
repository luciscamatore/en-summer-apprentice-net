using AutoMapper;
using TicketManagementSystem.DTO;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Profiles
{
    public class TicketCategoryProfile : Profile
    {
        public TicketCategoryProfile() {
            CreateMap<TicketCategory, TicketCategoryDTO>()
                .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.Event.EventName))
                .ReverseMap();
        }
    }
}
