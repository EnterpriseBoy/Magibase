using AutoMapper;

namespace MagiApi.Profiles
{
    public class EventProfile:Profile
    {
        public EventProfile()
        {
            CreateMap<Entities.Event, Models.EventDto>();
        }
    }
}
