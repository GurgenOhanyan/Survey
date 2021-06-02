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
            throw new NotImplementedException();
        }

        public void Delete(Question entity)
        {
            throw new NotImplementedException();
        }

        public IList<Question> ReadAll()
        {
            return this.context.Questions.ToList();
        }

        public Question ReadById(int id)
        {
            return this.context.Questions.Find(id);
        }

        public Question Update(Question entity)
        {
            Question trackedEntity = this.context.Questions.Find(entity);

            trackedEntity.Options = entity.Options;
        
            this.context.SaveChanges();
            return trackedEntity;
        }
    }
}
