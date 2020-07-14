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
        private EventStaffContext _context;

        public EventRepository(EventStaffContext eventStaffContext)
        {
            _context = eventStaffContext?? throw new ArgumentNullException(nameof(eventStaffContext));
        }



        public Event GetEvent(int eventId)
        {
            return _context.Events.FirstOrDefault(x => x.Id == eventId);
        }

        public IEnumerable<Event> GetEvents()
        {
            return _context.Events.ToList();
        }

        public bool EventExists(int eventId)
        {
            if (eventId.Equals(null))
            {
                throw new ArgumentNullException(nameof(eventId));
            }

            return _context.Events.Any(a => a.Id == eventId);
        }

        public void AddEvent(Event eventEntity)
        {
            _context.Add(eventEntity);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
