using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models.Repository
{
    public interface IAnswerRepository : IRepository<Answer, int>
    {
        IList<Answer> GetSurveyAnswers(Participant participant);
        IList<Answer> GetAnswersBySurveyID(int id);

        int CreateAnswersforSurvey(int surveyId, int ParticipantId);
        Answer CreateAnswerForQuestion(int questionId, int participantId);
    }
}
