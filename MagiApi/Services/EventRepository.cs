using MagiApi.Context;
using MagiApi.Entities;
using MagiApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagiApi.Services
{
    public class EventRepository : IEventRepository
    {
        private EventStaffContext context;

        public EventRepository(EventStaffContext eventStaffContext)
        {
            context = eventStaffContext?? throw new ArgumentNullException(nameof(context));
        }
        public Event GetEvent(int eventId)
        {
            return context.Events.First(x => x.Id == eventId);
        }

        public IEnumerable<Event> GetEvents()
        {
            return context.Events.ToList();
        }
    }
}
