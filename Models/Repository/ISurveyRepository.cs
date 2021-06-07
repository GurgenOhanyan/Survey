using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models.Repository
{
    public interface ISurveyRepository : IRepository<Survey, int>
    {
        public Task<List<Survey>> RealAllIncludeCompany();
        public Task<Survey> ReadById(int? id);
        public bool SurveyExists(int id);
        public Task<Survey> CreateAsync(Survey entity);
        public Task<Survey> UpdateAsync(Survey entity);
        public Company GetCompany(string id);
        public List<QuestionTypes> GetQuestionTypes();
    }
}
