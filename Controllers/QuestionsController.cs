﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Survey.Data;
using Survey.Models;
using Survey.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionRepository questionRepo;
        private readonly ApplicationDbContext context;
        public QuestionsController(IQuestionRepository questionRepository, ApplicationDbContext dbContext)
        {
            questionRepo = questionRepository;
            context = dbContext;
        }
        // GET: QuestionsController
        public ActionResult Index()
        {
            return View();
        }
        //Get All Questions
        [HttpGet]
        public async Task<ActionResult> AllQuestions()
        {
            int SurveyId = 0;
            
            if (HttpContext.Session.GetInt32("SurveyId") != null)
            {
                SurveyId = Convert.ToInt32(HttpContext.Session.GetInt32("SurveyId"));
                
                Models.Survey survey = context.Survey.Find(SurveyId);
                survey.status = Status.Completed;
                survey.QuestionsCount = this.context.Questions.Where(o => o.SurveyId == SurveyId).Count();
                context.Survey.Update(survey);
                await context.SaveChangesAsync();
            }
            var questions = await this.questionRepo.ReadAllBySurvey(SurveyId);
            return View(questions);
        }

        // POST: Questions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Header,QuestionType,Option1,Option2,Option3,Option4,Option5")] QuestionModelView questionModelView)
        {
            int SurveyId = 0;
            if (HttpContext.Session.GetInt32("SurveyId") != null) SurveyId = Convert.ToInt32(HttpContext.Session.GetInt32("SurveyId"));
       
            if (ModelState.IsValid)
            {
                if(questionModelView.Header==null)
                {
                    throw new Exception("Please insert the question title");
                }
                Question question = new Question();
                question.Header = questionModelView.Header;
                question.QuestionType = questionModelView.QuestionType;
                question.SurveyId = SurveyId;
                await questionRepo.CreateAsync(question);

                if (!String.IsNullOrEmpty(questionModelView.Option1)) 
                { 
                    Option option1 = new Option { Name = questionModelView.Option1, QuestionId = question.Id };
                    context.Options.Add(option1);
                }
                if (!String.IsNullOrEmpty(questionModelView.Option2))
                {
                    Option option2 = new Option { Name = questionModelView.Option2, QuestionId = question.Id };
                    context.Options.Add(option2);
                }
                if (!String.IsNullOrEmpty(questionModelView.Option3))
                {
                    Option option3 = new Option { Name = questionModelView.Option3, QuestionId = question.Id };
                    context.Options.Add(option3);
                }
                if (!String.IsNullOrEmpty(questionModelView.Option4))
                { 
                    Option option4 = new Option { Name = questionModelView.Option4, QuestionId = question.Id };
                    context.Options.Add(option4);
                }
                if (!String.IsNullOrEmpty(questionModelView.Option5))
                {
                    Option option5 = new Option { Name = questionModelView.Option5, QuestionId = question.Id };
                    context.Options.Add(option5);
                }
                context.SaveChanges();
            }
            return RedirectToAction("Create", "Survey", new { surveyId = SurveyId });
        }

        // GET: QuestionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionsController/Delete/5
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
    }
}
