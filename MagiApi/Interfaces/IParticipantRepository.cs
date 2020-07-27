using MagiApi.Models;
using System.Collections.Generic;

namespace MagiApi.Interfaces
{
    public interface IParticipantRepository
    {
        IEnumerable<Participant> GetParticipants();
        Participant GetParticipant(int participantId);
        bool ParticipantExists(int participantId);
        void AddParticipant(Participant participantEntity);
        bool Save();
    }
}
