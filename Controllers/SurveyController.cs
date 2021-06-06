using Microsoft.AspNetCore.Mvc;
using Survey.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Controllers
{
    //[ApiController]
    //[Route("{controller}")]
    public class SurveyController : Controller
    {
        private ISurveyRepository surveyRepository;
        private IQuestionRepository questionRepository;
        public SurveyController(ISurveyRepository surveyRepository, IQuestionRepository questionRepository)
        {
            this.surveyRepository = surveyRepository;
            this.questionRepository = questionRepository;
        }
        public IActionResult Index()
        {
            var surveys = this.surveyRepository.ReadAll();
            return View(surveys);
        }

        [HttpGet]
        [Route("ShowSurvey")]
        public ActionResult ShowSurvey([FromQuery] int id)
        {
            var questionList = this.questionRepository.GetQuestionsBySurveyId(id);
            return View(questionList);
        }
    }
}
