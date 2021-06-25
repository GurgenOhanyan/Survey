using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survey.Data;
using Survey.Models;
using Survey.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult Index(List<Answer> answers)
        {
            //for (int i = 0; i < answers.Count; i++)
            //{
            //    answerRepository.Update(answers[i]);
            //}
            return View(answers);
        }


        // GET: AnswersController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = answerRepository.ReadById(id);
            if (answer == null)
            {
                return NotFound();
            }
            return View(answer);
            //return View();
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
        public ActionResult Edit(int id, /*[Bind("Id, AnswerText, AnswerValue, AnswerBool")]*/ Answer answer/*IFormCollection collection*/)
        {
            if (id != answer.Id)
            {
                return NotFound();
            }

            answerRepository.Update(answer);
            context.SaveChangesAsync();

            return View();

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
        public ActionResult Answers(int SurveyId)
        {
            var answers = this.context.Answers.Where(a => a.Question.SurveyId == SurveyId)
                .Include(p => p.Participant)
                .Include(q => q.Question)
                .ThenInclude(q => q.Options).ToList();

            var groupAnswers = answers.GroupBy(o => o.Participant);
            List<AnswerViewModel> answersView = new List<AnswerViewModel>();
            foreach (var group in groupAnswers)
            {
                answersView.Add(new AnswerViewModel()
                {
                    participant = group.Key,
                    Answers = group
                });
            }
            return View(answersView);
        }
        public ActionResult AllSurveys()
        {
            return RedirectToAction("AllSurveys", "Survey");
        }

    }
}
