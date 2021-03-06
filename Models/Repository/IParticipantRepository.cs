using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models.Repository
{
    public interface IParticipantRepository : IRepository<Participant, int>
    {
        void Add(Participant entity);
    }
}
