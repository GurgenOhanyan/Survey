using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Survey.Data;
using Survey.Models;
using Survey.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Controllers
{
    //[ApiController]
    //[Route("{survey}")]
    public class SurveyController : Controller
    {
        private readonly ISurveyRepository surveyRepo;
        private readonly ApplicationDbContext context;
        public SurveyController(ApplicationDbContext context, ISurveyRepository surveyRepository)
        {
            surveyRepo = surveyRepository;
            this.context = context;
        }
        // GET: Survey
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Survey/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var survay = await surveyRepo.ReadByIdAsync(id);
            var survay = await context.Survey
                .Include(q => q.Questions)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (survay == null)
            {
                return NotFound();
            }

            return View(survay);
        }
        //Get All Surveys
        [HttpGet]
        //[Route("{survey}")]
        //[Route("AllSurveys")]
        public async Task<ActionResult> AllSurveys()
        {
            //var surveys = this.surveyRepo.ReadAll();
            var surveys = await this.surveyRepo.ReadAllCompleatedAsync();
            return View(surveys);
        }

        // POST: Survey/Create
        //[HttpPost]

        public async Task<IActionResult> Create()
        {
            int SurveyId = 0;
            if (HttpContext.Session.GetInt32("SurveyId") != null) SurveyId = Convert.ToInt32(HttpContext.Session.GetInt32("SurveyId"));

            if (SurveyId == 0)
            {
                Models.Survey survey = new Models.Survey();
                if (ModelState.IsValid)
                {
                    survey.QuestionsCount = 0;
                    survey.CompanyId = User.Claims.First().Value;
                    survey.status = Status.Draft;
                    await surveyRepo.CreateAsync(survey);
                    HttpContext.Session.SetInt32("SurveyId", survey.Id);
                    ViewBag.QuestionsCount = survey.QuestionsCount;
                }
            }
            else
            {
                Models.Survey survey = await surveyRepo.ReadByIdAsync(SurveyId);
                survey.status = Status.Active;
                ViewBag.QuestionsCount = survey.QuestionsCount;
                await surveyRepo.UpdateAsync(survey);
            }
            
            var enumData = from QuestionType e in Enum.GetValues(typeof(QuestionType))
                           select new
                           {
                               Id = (int)e,
                               Name = e.ToString()
                           };
            ViewData["QuestionTypes"] = new SelectList(enumData,"Id","Name");
           
            return View();
        }

        public ActionResult Fill(int id)
        { 
            return RedirectToAction("SurveyQuestions", "Questions", new { surveyId = id });
        }
        public ActionResult Answers(int id)
        {
            return RedirectToAction("Answers", "Answers", new { surveyId = id });
        }
        public ActionResult GenerateLink(int id)
        {
            var fullUrl = this.Url.Action("SurveyQuestions", "Questions", new { surveyId = id });
            ViewBag.ReturnUrl = "https://localhost:5001" + fullUrl;
            return View();
        }
    }
}
