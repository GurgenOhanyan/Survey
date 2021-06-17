﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.Data;
using Survey.Models;
using Survey.Models.Repository;
using System;
using System.Collections.Generic;

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

        [HttpGet]
        public ActionResult CreateAnswersforSurvey(int surveyId, int participantId)
        {
            var questions = questionRepository.SurveyQuestions(surveyId);

            foreach (var item in questions)
            {
                Answer temp = answerRepository.CreateAnswerForQuestion(item.Id, participantId);
            }

            List<Answer> answers = new List<Answer>();
            answers = (List<Answer>)answerRepository.GetAnswersBySurveyID(surveyId);
            return View(answers);
        }

        [HttpPost]
        public ActionResult CreateAnswersforSurvey(List<Answer> answers)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                answerRepository.Update(answers[i]);
            }

            return View(answers);
        }
    }
}
