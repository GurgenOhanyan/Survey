using Survey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models.Repository
{
    public class SurveyRepository : ISurveyRepository
    {
        private ApplicationDbContext context;
        public SurveyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Survey Create(Survey entity)
        {
            this.context.Survey.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public void Delete(Survey entity)
        {
            Survey trackedEntity = this.context.Survey.Find(entity.Id);

            if (trackedEntity != null)
            {
                this.context.Survey.Remove(trackedEntity);
                this.context.SaveChanges();
            }
        }

        public IList<Survey> ReadAll()
        {
            return this.context.Survey.ToList();
        }

        public Survey ReadById(int id)
        {
            return context.Survey.Find(id);
        }

        public Survey Update(Survey entity)
        {
            Survey trackedEntity = this.context.Survey.Find(entity.Id);

            trackedEntity.Questions = entity.Questions;
            trackedEntity.QuestionsCount = entity.QuestionsCount;

            if (entity.
                Id != 0 && string.IsNullOrEmpty(entity.CompanyName))
            {
                trackedEntity.CompanyId = entity.CompanyId;
                trackedEntity.CompanyName = entity.CompanyName;
            }
            this.context.SaveChanges();
            return trackedEntity;
        }
    }
}
