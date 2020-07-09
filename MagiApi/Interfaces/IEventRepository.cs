using MagiApi.Entities;
using System.Collections.Generic;

namespace MagiApi.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetEvents();
        Event GetEvent(int eventId);
        bool EventExists(int eventId);
        void AddEvent(Event eventEntity);
        bool Save();
    }
}
