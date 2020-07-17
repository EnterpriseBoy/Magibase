using MagiApi.Context;
using MagiApi.Entities;
using MagiApi.Interfaces;
using MagiApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagiApi.Services
{
    public class UserRepository : IParticipantRepository
    {
        private EventStaffContext _context;

        public UserRepository(EventStaffContext eventStaffContext)
        {
            _context = eventStaffContext?? throw new ArgumentNullException(nameof(eventStaffContext));
        }

        public Participant GetParticipant(int participantId)
        {
            return _context.Participants.FirstOrDefault(x => x.ParticipantId == participantId);
        }

        public IEnumerable<Participant> GetParticipants()
        {
            return _context.Participants.ToList();
        }

        public bool ParticipantExists(int participantId)
        {
            if (participantId.Equals(null))
            {
                throw new ArgumentNullException(nameof(participantId));
            }

            return _context.Participants.Any(a => a.ParticipantId == participantId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void AddParticipant(Participant participantEntity)
        {
            throw new NotImplementedException();
        }
    }
}
