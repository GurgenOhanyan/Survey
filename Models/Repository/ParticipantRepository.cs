using Survey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models.Repository
{
    public class ParticipantRepository : IParticipantRepository
    {
        private ApplicationDbContext context;
        public ParticipantRepository(ApplicationDbContext context)
        {
            this.context = context;
                
        }

        public void AddParticipant(string firstName, string lastName, DateTime birdtDate)
        {
            Participant participant = new Participant();
            participant.FirstName = firstName;
            participant.Lastname = lastName;
            participant.BirthDate = birdtDate;
            
            this.context.Participants.Add(participant);
            this.context.SaveChanges();
        }

        public Participant Create(Participant entity)
        {
            this.context.Participants.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public void Delete(Participant entity)
        {
            throw new NotImplementedException();
        }

        public IList<Participant> ReadAll()
        {
            return this.context.Participants.ToList();
        }

        public Participant ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Participant Update(Participant entity)
        {
            throw new NotImplementedException();
        }
    }
}
