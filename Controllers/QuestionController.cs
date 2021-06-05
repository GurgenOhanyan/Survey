using Microsoft.AspNetCore.Mvc;
using Survey.Models;
using Survey.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class QuestionController : Controller
    {
        private IQuestionRepository questionRepository;
        private ISurveyRepository surveyRepository;
        public QuestionController(IQuestionRepository questionRepository, ISurveyRepository surveyRepository)
        {
            this.questionRepository = questionRepository;
            this.surveyRepository = surveyRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<Question> GetQuestionsBySurveyId([FromQuery] int id)
        {
            var questionList = this.questionRepository.GetQuestionsBySurveyId(id);
            if (questionList == null || !questionList.Any() )
                return NotFound();

            string companyName = surveyRepository.ReadById(
                questionList.First()
                .SurveyId)
                .CompanyName
                .ToString();

            ViewData["company"] = companyName;
            return View(questionList);
        }
    }
}
