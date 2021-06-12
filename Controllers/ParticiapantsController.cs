using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Models.Repository;
using Survey.Models;

namespace Survey.Controllers
{
    public class ParticiapantsController : Controller
    {
        private readonly IParticipantRepository participantRepository;

        public ParticiapantsController(IParticipantRepository participantRepository)
        {
            this.participantRepository = participantRepository;
        }

        // GET: ParticiapantsController
        public ActionResult Index()
        {
            var partisipants = this.participantRepository.ReadAll();
            return View(partisipants);
        }

        // GET: ParticiapantsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParticiapantsController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind("FirstName, LastName, BirthDate")] Participant participant)
        {
            if (ModelState.IsValid)
                this.participantRepository.Add(participant);

            return RedirectToAction(nameof(Index));

        }

        // POST: ParticiapantsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: ParticiapantsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParticiapantsController/Edit/5
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

        // GET: ParticiapantsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParticiapantsController/Delete/5
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
