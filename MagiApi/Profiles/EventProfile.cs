using AutoMapper;
using MagiApi.Models.Event;

namespace MagiApi.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Entities.Event, EventDto>();
            CreateMap<EventCreateDto,Entities.Event>();
        }
    }
}
