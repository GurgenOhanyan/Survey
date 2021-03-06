using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models.Repository
{
    public interface IQuestionRepository : IRepository<Question, int>
    {
        public Task<Question> CreateAsync(Question entity);
        public Task<List<Question>> ReadAllBySurvey(int serveyId);
        public IEnumerable<Question> SurveyQuestions(int surveyId);
    }
}
