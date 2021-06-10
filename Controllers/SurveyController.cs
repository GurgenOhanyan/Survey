using Microsoft.AspNetCore.Http;
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
        public SurveyController(ISurveyRepository surveyRepository)
        {
            surveyRepo = surveyRepository;
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

            var survay = await surveyRepo.ReadByIdAsync(id);
            if (survay == null)
            {
                return NotFound();
            }

            return View(survay);
        }
        //Get All Surveys
        [HttpGet]
        [Route("{survey}")]
        [Route("AllSurveys")]
        public ActionResult AllSurveys()
        {
            var surveys = this.surveyRepo.ReadAll();

            //temporory list for tests
            //var surveys = new List<Models.Survey>();
            //surveys.Add(new Models.Survey { Id = 1, Company = new Models.Company(), CompanyId = 2, CompanyName = "TROSIFOL", Questions = null, QuestionsCount = 3 });
            //surveys.Add(new Models.Survey { Id = 2, Company = new Models.Company(), CompanyId = 225, CompanyName = "ALUTECH", Questions = null, QuestionsCount = 8 });
            //surveys.Add(new Models.Survey { Id = 3, Company = new Models.Company(), CompanyId = 21, CompanyName = "MACO", Questions = null, QuestionsCount = 7 });

            return View(surveys);
        }
        // GET: Survey/Create
        // [Route("{surveyId}", Name = "NiceUrlForVehicleMakeLookup")]
        //[Route("{surveyId}")]
        //public async Task<IActionResult> Create(string surveyId)
        //{
        //    Models.Survey survay = await surveyRepo.ReadByIdAsync(Convert.ToInt32(surveyId));
        //    survay.status = Status.Active;
        //    survay.QuestionsCount = survay.QuestionsCount + 1;
        //    return View();
        //}

        // POST: Survey/Create
        //[HttpPost]
        // [ValidateAntiForgeryToken]
        //Company company

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
                    survey.CompanyId = "1";
                    survey.status = Status.Draft;
                    await surveyRepo.CreateAsync(survey);
                    //ViewData["SurveyId"] = survey.Id;
                    HttpContext.Session.SetInt32("SurveyId", survey.Id);
                }
            }
            else
            {
                Models.Survey survey = await surveyRepo.ReadByIdAsync(SurveyId);
                survey.status = Status.Active;
                //survey.QuestionsCount = survey.QuestionsCount + 1;
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
      
        //// GET: SurveyController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Survey/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Models.Survey survey)
        {
            if (id != survey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
        {
                try
                {
                    await surveyRepo.UpdateAsync(survey);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!surveyRepo.SurveyExists(survey.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return View(survey);

            }
            return View(survey);
        }

        // GET: SurveyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
            
        // POST: SurveyController/Delete/5
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
