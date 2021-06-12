using Microsoft.EntityFrameworkCore;
using Survey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private ApplicationDbContext context;
        public QuestionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Question Create(Question entity)
        {
            this.context.Questions.Add(entity);
            this.context.SaveChanges();
            return entity;
        }
        public async Task<Question> CreateAsync(Question entity)
        {
            this.context.Questions.Add(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }
        public IEnumerable<Question> SurveyQuestions(int surveyId)
        {
            return this.context.Questions.Where(o => o.SurveyId == surveyId).ToList();
        }

        public void Delete(Question entity)
        {
            Question trackedEntity = this.context.Questions.Find(entity.Id);

            if (trackedEntity != null)
            {
                this.context.Questions.Remove(trackedEntity);
                this.context.SaveChangesAsync();
        }
        }

        public IList<Question> ReadAll()
        {
            return this.context.Questions.ToList();
        }

        public async Task<List<Question>> ReadAllBySurvey(int surveyId)
        {
            return await this.context.Questions.Where(o => o.SurveyId == surveyId).ToListAsync();
        }

        public Question ReadById(int id)
        {
            return this.context.Questions.Find(id);
        }

        public Question Update(Question entity)
        {
            Question trackedEntity = this.context.Questions.Find(entity.Id);

            trackedEntity.Header = entity.Header;
            trackedEntity.QuestionType = entity.QuestionType;
            trackedEntity.SurveyId = entity.SurveyId;
            trackedEntity.Options = entity.Options;
        
            this.context.SaveChanges();
            return trackedEntity;
        }
    }
}
