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
        public QuestionController(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Question> GetQuestionsBySurveyId([FromQuery] int id)
        {
            var questionList = questionRepository.GetQuestionsBySurveyId(id);
            if (questionList == null || !questionList.Any() )
                return NotFound();

            return View(questionList);
        }
    }
}
