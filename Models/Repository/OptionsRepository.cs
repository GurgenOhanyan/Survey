using Survey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models.Repository
{
    public class OptionsRepository : IOptionsRepository
    {
        private ApplicationDbContext context;
        public OptionsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Option Create(Option entity)
        {
            this.context.Options.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public void Delete(Option entity)
        {
            Option trackedEntity = this.context.Options.Find(entity);
            if (trackedEntity != null)
            {
                this.context.Options.Remove(entity);
                this.context.SaveChanges();
            }
        }

        public IList<Option> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Option ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Option Update(Option entity)
        {
            throw new NotImplementedException();
        }
    }
}
