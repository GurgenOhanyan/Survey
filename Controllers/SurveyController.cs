using Microsoft.AspNetCore.Mvc;
using Survey.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Controllers
{
    [ApiController]
    [Route("{survey}")]
    public class SurveyController : Controller
    {
        private ISurveyRepository surveyRepository; 
        public SurveyController(ISurveyRepository surveyRepository)
        {
            this.surveyRepository = surveyRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Get All Surveys
        [HttpGet]
        [Route("AllSurveys")]
        public ActionResult AllSurveys()
        {
            var surveys = this.surveyRepository.ReadAll();

            //temporory list for tests
            //var surveys = new List<Models.Survey>();
            //surveys.Add(new Models.Survey { Id = 1, Company = new Models.Company(), CompanyId = 2, CompanyName = "TROSIFOL", Questions = null, QuestionsCount = 3 });
            //surveys.Add(new Models.Survey { Id = 2, Company = new Models.Company(), CompanyId = 225, CompanyName = "ALUTECH", Questions = null, QuestionsCount = 8 });
            //surveys.Add(new Models.Survey { Id = 3, Company = new Models.Company(), CompanyId = 21, CompanyName = "MACO", Questions = null, QuestionsCount = 7 });
            
            return View(surveys);
        }
    }
}
