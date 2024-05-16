using AutoMapper;
using Concert.Dto;
using Concert.Entities;

namespace Concert.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile() 
        {
            CreateMap<TicketEntity, TicketDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.CO2, opt => opt.MapFrom(src => src.CO2))
                .ReverseMap();
        }
    }
}
