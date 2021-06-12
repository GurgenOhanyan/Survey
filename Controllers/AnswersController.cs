using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.Data;
using Survey.Models;
using Survey.Models.Repository;
using System;

namespace Survey.Controllers
{
    public class AnswersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IQuestionRepository questionRepository;
        private readonly IAnswerRepository answerRepository;

        public AnswersController(ApplicationDbContext dbContext, IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            this.context = dbContext;
            this.questionRepository = questionRepository;
            this.answerRepository = answerRepository;
        }

        // GET: AnswersController
        public ActionResult Index()
        {
            var answers = answerRepository.ReadAll();
            return View(answers);
        }

        // GET: AnswersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnswersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnswersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnswersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnswersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnswersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnswersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreatAnswerForQuestion(int questionId, int participantId)
        {

            Question q = questionRepository.ReadById(questionId);
            TempData["Header"] = q.Header;
            TempData["QuestionType"] = q.QuestionType;
            TempData["QuestionId"] = q.Id;
            TempData["participantId"] = participantId;


            //Answer a = answerRepository.ReadById(1);
            //questionId = 1;
            Answer answer = new Answer();
            answer.ParticipantID = participantId;
            answer.QuestionId = questionId;

            return View(answer);
        }

        [HttpPost]
        public ActionResult CreatAnswerForQuestion(Answer answer)
        {
            answer.QuestionId = Convert.ToInt32(TempData["QuestionId"]);
            answer.ParticipantID = Convert.ToInt32(TempData["participantId"]);

            if (ModelState.IsValid)
            {
                answerRepository.Create(answer);
                return RedirectToAction(nameof(Index));
            }
            return View(answer);
        }


        ////hin
        //public ActionResult CreateAnswersforSurvey(int surveyId, int participantId)
        //{
        //    var questions = questionRepository.SurveyQuestions(surveyId);

        //    foreach (var item in questions)
        //    {
        //        CreatAnswerForQuestion(item.Id, participantId);
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        //nor
        [HttpGet]
        public ActionResult CreateAnswersforSurvey(int surveyId, int participantId)
        {
            var questions = questionRepository.SurveyQuestions(surveyId);

            foreach (var item in questions)
            {
                if (item.QuestionType is QuestionType.Options)
                    answerRepository.Create(new Answer() { ParticipantID = participantId, QuestionId = item.Id, AnswerValue = 0 });

                if (item.QuestionType is QuestionType.YesNo)
                    answerRepository.Create(new Answer() { ParticipantID = participantId, QuestionId = item.Id, AnswerBool = false });

                if (item.QuestionType is QuestionType.Text)
                    answerRepository.Create(new Answer() { ParticipantID = participantId, QuestionId = item.Id, AnswerText = "" });
            }

            var answers = answerRepository.GetAnswersBySurbeyID(surveyId);
            return View(answers);
        }
    }
}
