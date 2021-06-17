using Microsoft.EntityFrameworkCore;
using Survey.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models.Repository
{
    public class AnswerRepository : IAnswerRepository
    {
        private ApplicationDbContext context;

        public AnswerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Answer Create(Answer entity)
        {
            this.context.Answers.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public Answer CreateAnswerForQuestion(int questionId, int participantId)
        {
            Answer answer = new Answer();
            answer.AnswerBool = false;
            answer.AnswerText = string.Empty;
            answer.AnswerValue = 0;
            answer.ParticipantID = participantId;
            answer.QuestionId = questionId;

            Create(answer);
            return answer;
        }

        public int CreateAnswersforSurvey(int surveyId, int participantId = 1)
        {
            var questions = this.context.Questions.Where(q => q.SurveyId == surveyId);
            foreach (var s in questions)
            {
                CreateAnswerForQuestion(s.Id, participantId);
            }
            return surveyId;
        }


        public async Task<Answer> CreateAsync(Answer entity)
        {
            this.context.Answers.Add(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }

        public void Delete(Answer entity)
        {
            Answer tratrackedEntity = context.Answers.Find(entity.Id);
            if (tratrackedEntity != null)
            {
                this.context.Answers.Remove(tratrackedEntity);
                this.context.SaveChanges();
            }

        }

        public IList<Answer> GetAnswersBySurveyID(int id)
        {
            return this.context.Answers.Where(a => a.Question.SurveyId == id)
                .Include(q => q.Question)
                .ThenInclude(q => q.Options)
                .AsNoTracking()


                .ToList();
        }

        public IList<Answer> GetSurveyAnswers(Participant participant)
        {
            return this.context.Answers.Where(a => a.Participant.Id == participant.Id).ToList();
        }

        public IList<Answer> ReadAll()
        {
            return this.context.Answers.ToList();
        }


        public Answer ReadById(int id)
        {
            return this.context.Answers.FirstOrDefault(a => a.Id == id);
        }

        public Answer Update(Answer entity)
        {
            Answer trackedEntity = this.context.Answers.Find(entity.Id);

            trackedEntity.AnswerBool = entity.AnswerBool;
            trackedEntity.AnswerText = entity.AnswerText;
            trackedEntity.AnswerValue = entity.AnswerValue;
            trackedEntity.ParticipantID = entity.ParticipantID;

            this.context.SaveChanges();
            return trackedEntity;
        }
    }
}
